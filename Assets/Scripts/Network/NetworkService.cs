using Photon.Pun;

namespace Network
{
    internal class NetworkService : INetworkService
    {
        private readonly NetworkLobbyService _networkLobbyService;
        private readonly NetworkConnectionService _networkConnectionService;

        private NetworkService(NetworkLobbyService networkLobbyService, NetworkConnectionService networkConnectionService)
        {
            _networkLobbyService = networkLobbyService;
            _networkConnectionService = networkConnectionService;
        }

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

        public void GetRoomList()
        {
            // PhotonNetwork.
            // PhotonNetwork.GetCustomRoomList();
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