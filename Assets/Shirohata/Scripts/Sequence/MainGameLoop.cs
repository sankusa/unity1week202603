using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;

namespace ShirohataLabo.u1w202603
{
    public class MainGameLoop : IDisposable
    {
        readonly Tablet _tablet;
        readonly Wisdom _wisdom;
        readonly ClickPower _clickPower;
        readonly ClickChecker _clickChecker;

        readonly TabletTurner _tabletTurner;

        readonly CompositeDisposable _disposables = new();

        public MainGameLoop(Tablet tablet, Wisdom wisdom, ClickPower clickPower, ClickChecker clickChecker)
        {
            _tablet = tablet;
            _wisdom = wisdom;
            _clickPower = clickPower;
            _clickChecker = clickChecker;

            _tabletTurner = new TabletTurner(_tablet);
        }

        public void Dispose()
        {
            _disposables.Clear();
        }

        public async UniTask StartGameLoopAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _tablet.OnWisdomGenerated
                .Subscribe(value =>
                {
                    _wisdom.Add(value);
                })
                .AddTo(_disposables);

            _clickChecker
                .OnClick
                .Subscribe(_ => _tabletTurner.AddAdditionalSpeed(_clickPower.Power))
                .AddTo(_disposables);

            while(true)
            {
                _tabletTurner.Tick();

                await UniTask.Yield(cancellationToken);
            }
        }
    }
}