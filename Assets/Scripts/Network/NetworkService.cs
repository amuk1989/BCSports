using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Fusion;
using UniRx;
using UnityEngine;

namespace Network
{
    internal class NetworkService : INetworkService
    {
        private readonly BasicSpawner _basicSpawner;
        private readonly NetworkObjectFactory _networkObjectFactory;
        private readonly GameMode _gameMode;

        public NetworkService(BasicSpawner basicSpawner, NetworkObjectFactory networkObjectFactory)
        {
            _basicSpawner = basicSpawner;
            _networkObjectFactory = networkObjectFactory;
        }

        public IObservable<Unit> OnConnected => _basicSpawner.OnConnectedAsRx;

        public bool IsHostGame => _gameMode == GameMode.Host;

        public void Initialize()
        {
            
        }

        public void Dispose()
        {
        }

        public void CreateNewLobby()
        {
            _basicSpawner.TryStartGameAsync(GameMode.Host).Forget();
        }

        public void ConnectToLobby()
        {
            _basicSpawner.TryStartGameAsync(GameMode.Client).Forget();
        }

        public void CreateNewNetworkObject<TComponent>(TComponent prefab) where TComponent : MonoBehaviour
        {
            if (IsHostGame)
            {
                _networkObjectFactory.Create(prefab, null, Vector3.zero);
            }
        }
    }
}