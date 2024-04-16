using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Network
{
    internal class NetworkService : INetworkService
    {

        public IObservable<Unit> OnRoomListUpdated => null;

        public void Initialize()
        {

        }

        public void Dispose()
        {

        }

        public void CreateNewLobby()
        {

        }

        private async UniTask InitializeAsync(CancellationToken cancellationToken)
        {
            
        }
    }
}