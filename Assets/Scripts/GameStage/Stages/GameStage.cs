using System;
using GameStage.Interfaces;
using Network;
using UniRx;
using View;
using Object = UnityEngine.Object;

namespace GameStage.Stages
{
    public class GameStage : IGameStage
    {
        private readonly INetworkService _networkService;

        public GameStage(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public void Execute()
        {
            var prefab = Object.FindObjectOfType<GunView>();
            _networkService.CreateNewNetworkObject(prefab);
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