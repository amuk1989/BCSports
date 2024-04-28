using System;
using GameStage.Interfaces;
using Gun;
using Input.Interface;
using Network;
using Network.Data;
using UniRx;
using View;
using Object = UnityEngine.Object;

namespace GameStage.Stages
{
    public class GameStage : IGameStage
    {
        private readonly INetworkService _networkService;
        private readonly GameConfigData _gameConfig;
        private readonly IInputService _inputService;
        private readonly CompositeDisposable _compositeDisposable = new();

        public GameStage(INetworkService networkService, GameConfigData gameConfig, IInputService inputService)
        {
            _networkService = networkService;
            _gameConfig = gameConfig;
            _inputService = inputService;
        }

        //TODO : Need create similar states for host and server
        public void Execute()
        {
            _inputService.Initialize();

            _inputService
                .CursorPositionAsObservable()
                .Where(x => _inputService.TapStatus != TapStatus.OnDrag)
                .Subscribe(position =>
                {
                    _networkService.SetNetworkInput(new NetworkInputData(position));
                })
                .AddTo(_compositeDisposable);
            
            if (!_networkService.IsHostGame) return;

            _networkService.CreateNewNetworkObject(_gameConfig.NetworkComponent, _networkService.LocalPlayer);

            _networkService
                .OnConnected
                .Subscribe(player => _networkService.CreateNewNetworkObject(_gameConfig.NetworkComponent, player))
                .AddTo(_compositeDisposable);
        }

        public void Complete()
        {
            _inputService.StopTrackInput();
            _compositeDisposable?.Dispose();
        }

        public IObservable<Unit> StageCompletedAsRx()
        {
            return Observable.Never<Unit>();
        }
    }
}