using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Fusion;
using Network.Data;
using UniRx;
using UnityEngine;

namespace Network
{
    internal class NetworkService : INetworkService
    {
        private readonly BasicSpawner _basicSpawner;
        private readonly NetworkObjectFactory _networkObjectFactory;

        private readonly Dictionary<PlayerRef, NetworkBehaviour> _networkObjects = new();

        private GameMode _gameMode;

        public NetworkService(BasicSpawner basicSpawner, NetworkObjectFactory networkObjectFactory)
        {
            _basicSpawner = basicSpawner;
            _networkObjectFactory = networkObjectFactory;
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
        }

        public async UniTask CreateNewLobby()
        {
            var connectResult = await _basicSpawner.TryStartGameAsync(GameMode.Host);
            if (!connectResult) return;

            _gameMode = GameMode.Host;

            _basicSpawner
                .OnDisconnectedAsRx
                .Subscribe(DestroyObject);
        }

        public async UniTask ConnectToLobby()
        {
            var connectResult = await _basicSpawner.TryStartGameAsync(GameMode.Client);
            if (connectResult) _gameMode = GameMode.Client;
        }

        public void CreateNewNetworkObject<TComponent>(TComponent prefab, PlayerRef playerRef)
            where TComponent : NetworkBehaviour
        {
            if (IsHostGame)
                _networkObjects[playerRef] = _networkObjectFactory.Create(prefab, null, Vector3.zero, playerRef);
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