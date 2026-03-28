using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;
using R3;
using System;

namespace ShirohataLabo.u1w202603
{
    public class WisdomPresenter : IStartable, IDisposable
    {
        readonly Wisdom _wisdom;
        readonly WisdomView _wisdomView;

        readonly CompositeDisposable _disposables = new();

        public WisdomPresenter(Wisdom wisdom, WisdomView wisdomView)
        {
            _wisdom = wisdom;
            _wisdomView = wisdomView;
        }

        public void Start()
        {
            _wisdom.Value
                .Subscribe(value =>
                {
                    _wisdomView.UpdateValue(value);
                })
                .AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}