using System;
using System.Collections.Generic;
using Base;
using ModestTree;
using Photon.Pun;
using Photon.Realtime;
using UniRx;

namespace Network
{
    internal class NetworkLobbyService : ILobbyCallbacks, IService
    {
        private readonly ReactiveCommand _onRoomCollectionUpdated = new();
        private readonly List<RoomInfo> _roomList = new();

        public IObservable<Unit> OnRoomsUpdated => _onRoomCollectionUpdated.AsObservable();
        public IEnumerable<RoomInfo> Rooms => _roomList;

        public void OnJoinedLobby()
        {
            throw new NotImplementedException();
        }

        public void OnLeftLobby()
        {
            throw new NotImplementedException();
        }

        public void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            _roomList.Clear();
            _roomList.AllocFreeAddRange(roomList);
            _onRoomCollectionUpdated.Execute();
        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        public void Dispose()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }
    }
}