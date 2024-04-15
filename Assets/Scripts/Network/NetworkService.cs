using System;
using UniRx;

namespace Network
{
    internal class NetworkService : INetworkService
    {

        public IObservable<Unit> OnRoomListUpdated => null;

        public void Initialize()
        {
            InitializeCallbacks();
        }

        public void Dispose()
        {
            ReleaseCallBacks();
        }

        public void CreateNewLobby()
        {

        }

        private void InitializeCallbacks()
        {
        }

        private void ReleaseCallBacks()
        {
        }
    }
}