using System;
using Cysharp.Threading.Tasks;
using GameStage.Interfaces;
using Network;
using UniRx;

namespace GameStage.Stages
{
    public class MainMenuStage: IGameStage
    {
        private readonly INetworkService _networkService;
        private readonly ReactiveCommand _onComplete = new();

        private IDisposable _disposable;

        public MainMenuStage(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public void Execute()
        {
            _disposable = _networkService
                .OnConnected
                .Subscribe(_ => _onComplete.Execute());
        }

        public void Complete()
        {
            _disposable?.Dispose();
            _disposable = null;
        }

        public IObservable<Unit> StageCompletedAsRx() => _onComplete.AsObservable();
    }
}