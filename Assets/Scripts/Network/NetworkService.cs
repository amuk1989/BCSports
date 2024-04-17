using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Fusion;
using UniRx;

namespace Network
{
    internal class NetworkService : INetworkService
    {
        private readonly BasicSpawner _basicSpawner;

        public NetworkService(BasicSpawner basicSpawner)
        {
            _basicSpawner = basicSpawner;
        }

        public IObservable<Unit> OnConnected => _basicSpawner.OnConnectedAsRx;

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
    }
}