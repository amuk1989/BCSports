﻿using System;
using System.Collections.Generic;
using Base;
using Photon.Realtime;
using UniRx;

namespace Network
{
    public interface INetworkService : IService
    {
        IObservable<Unit> OnRoomListUpdated { get; }
        IEnumerable<RoomInfo> Rooms { get; }

        void CreateNewLobby()
        {
        }
    }
}