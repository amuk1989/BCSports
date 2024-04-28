using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Fusion;
using Gun;
using Network.Data;
using UniRx;
using UnityEngine;

namespace Network
{
    internal class NetworkService : INetworkService
    {
        private readonly BasicSpawner _basicSpawner;
        private readonly NetworkObjectFactory _networkObjectFactory;
        private readonly GameConfigData _gameConfig;

        private readonly Dictionary<PlayerRef, NetworkBehaviour> _networkObjects = new();
        private readonly CompositeDisposable _compositeDisposable = new();

        private GameMode _gameMode;

        public NetworkService(BasicSpawner basicSpawner, NetworkObjectFactory networkObjectFactory,
            GameConfigData gameConfig)
        {
            _basicSpawner = basicSpawner;
            _networkObjectFactory = networkObjectFactory;
            _gameConfig = gameConfig;
        }

        public IObservable<PlayerRef> OnConnected => _basicSpawner.OnConnectedAsRx;

        public IObservable<PlayerRef> OnDisconnected => _basicSpawner.OnDisconnectedAsRx;

        public bool IsHostGame => _gameMode == GameMode.Host;

        public PlayerRef LocalPlayer => _basicSpawner.PlayerRef;

        public void Initialize()
        {
        }

        public void Dispose()
        {
            if (!IsHostGame) return;

            foreach (var networkObject in _networkObjects) DestroyObject(networkObject.Key);

            _compositeDisposable?.Dispose();
        }

        public async UniTask CreateNewLobby()
        {
            _basicSpawner
                .OnDisconnectedAsRx
                .Subscribe(DestroyObject)
                .AddTo(_compositeDisposable);

            _basicSpawner
                .OnConnectedAsRx
                .Subscribe(player =>
                {
                    _networkObjects[player] = CreateNewNetworkObject(_gameConfig.NetworkComponent, player);
                })
                .AddTo(_compositeDisposable);

            var connectResult = await _basicSpawner.TryStartGameAsync(GameMode.Host);
            if (!connectResult) return;

            _gameMode = GameMode.Host;
        }

        public async UniTask ConnectToLobby()
        {
            var connectResult = await _basicSpawner.TryStartGameAsync(GameMode.Client);
            if (connectResult) _gameMode = GameMode.Client;
        }

        public TComponent CreateNewNetworkObject<TComponent>(TComponent prefab, PlayerRef playerRef)
            where TComponent : NetworkBehaviour
        {
            return IsHostGame ? _networkObjectFactory.Create(prefab, null, Vector3.zero, playerRef) : null;
        }

        private void DestroyObject(PlayerRef playerRef)
        {
            if (!IsHostGame || !_networkObjects.TryGetValue(playerRef, out var networkObject)) return;

            _networkObjectFactory.Destroy(networkObject.Object);
            _networkObjects.Remove(playerRef);
        }

        public void SetNetworkInput(NetworkInputData networkInputData)
        {
            _basicSpawner.SetInputData(networkInputData);
        }
    }
}