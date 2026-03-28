using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using ShirohataLib.Basic;
using UnityEngine;
using VContainer.Unity;

namespace ShirohataLabo.u1w202603
{
    public class MainSequence : IInitializable, IAsyncStartable, IDisposable
    {
        readonly MainGameLoop _mainGameLoop;
        readonly SaveData _saveData;

        public MainSequence(SaveData saveData, MainGameLoop mainGameLoop)
        {
            _saveData = saveData;
            _mainGameLoop = mainGameLoop;
        }

        public void Dispose()
        {

        }

        public void Initialize()
        {
            if (_saveData.HasKey())
            {
                _saveData.LoadOverWrite();
            }
        }

        public async UniTask StartAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                await _mainGameLoop.StartGameLoopAsync(cancellationToken);
            }
            catch(OperationCanceledException)
            {
                _saveData.Save();
                Debug.Log("Canceled");
            }
        }
    }
}