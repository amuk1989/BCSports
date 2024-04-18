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

        public GameStage(INetworkService networkService, GameConfigData gameConfig)
        {
            _networkService = networkService;
            _gameConfig = gameConfig;
        }

        public void Execute()
        {
            _networkService.CreateNewNetworkObject(_gameConfig.GunView);
        }

        public void Complete()
        {
        }

        public IObservable<Unit> StageCompletedAsRx()
        {
            return Observable.Never<Unit>();
        }
    }
}