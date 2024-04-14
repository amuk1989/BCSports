using System.Collections.Generic;
using Base;
using Photon.Pun;
using Photon.Realtime;

namespace Network
{
    internal class NetworkLobbyService : ILobbyCallbacks, IService
    {
        private List<RoomInfo> _roomList;
        public void Initialize()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        public void Dispose()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        public void OnJoinedLobby()
        {
            throw new System.NotImplementedException();
        }

        public void OnLeftLobby()
        {
            throw new System.NotImplementedException();
        }

        public void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            _roomList = roomList;
        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
        {
            throw new System.NotImplementedException();
        }
    }
}