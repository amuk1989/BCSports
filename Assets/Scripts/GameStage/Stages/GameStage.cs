using System;
using GameStage.Interfaces;
using Gun;
using Network;
using UniRx;
using View;
using Object = UnityEngine.Object;

namespace GameStage.Stages
{
    public class GameStage : IGameStage
    {
        private readonly INetworkService _networkService;
        private readonly GameConfigData _gameConfig;
        private readonly CompositeDisposable _compositeDisposable = new();

        public GameStage(INetworkService networkService, GameConfigData gameConfig)
        {
            _networkService = networkService;
            _gameConfig = gameConfig;
        }

        public void Execute()
        {
            if (_networkService.IsHostGame)
            {
                _networkService.CreateNewNetworkObject(_gameConfig.GunView);

                _networkService
                    .OnConnected
                    .Subscribe(_ =>
                    {
                        _networkService.CreateNewNetworkObject(_gameConfig.GunView);
                    })
                    .AddTo(_compositeDisposable);
            }
        }

        public void Complete()
        {
            _compositeDisposable?.Dispose();
        }

        public IObservable<Unit> StageCompletedAsRx()
        {
            return Observable.Never<Unit>();
        }
    }
}