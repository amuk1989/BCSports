using System;
using System.Collections.Generic;
using System.Globalization;
using Photon.Pun;
using Photon.Realtime;
using UniRx;

namespace Network
{
    internal class NetworkService : INetworkService
    {
        private readonly NetworkConnectionService _networkConnectionService;
        private readonly NetworkLobbyService _networkLobbyService;

        private NetworkService(NetworkLobbyService networkLobbyService,
            NetworkConnectionService networkConnectionService)
        {
            _networkLobbyService = networkLobbyService;
            _networkConnectionService = networkConnectionService;
        }

        public IObservable<Unit> OnRoomListUpdated => _networkLobbyService.OnRoomsUpdated;
        public IEnumerable<RoomInfo> Rooms => _networkLobbyService.Rooms;

        public void Initialize()
        {
            InitializeCallbacks();

            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = "1";
        }

        public void Dispose()
        {
            PhotonNetwork.Disconnect();
            ReleaseCallBacks();
        }

        public void CreateNewLobby()
        {
            RoomOptions options = new RoomOptions {MaxPlayers = 4, PlayerTtl = 10000 };
            PhotonNetwork.CreateRoom($"Lobby {DateTime.Now.ToString(CultureInfo.CurrentCulture)}", options);
        }

        private void InitializeCallbacks()
        {
            _networkConnectionService.Initialize();
            _networkLobbyService.Initialize();
        }

        private void ReleaseCallBacks()
        {
            _networkConnectionService.Dispose();
            _networkLobbyService.Dispose();
        }
    }
}