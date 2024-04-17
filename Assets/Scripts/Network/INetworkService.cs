using System;
using Base;
using UniRx;

namespace Network
{
    public interface INetworkService : IService
    {
        IObservable<Unit> OnConnected { get; }
        void CreateNewLobby();
        void ConnectToLobby();
    }
}