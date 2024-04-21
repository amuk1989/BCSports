using System;
using Base;
using UniRx;
using UnityEngine;

namespace Network
{
    public interface INetworkService : IService
    {
        IObservable<Unit> OnConnected { get; }
        bool IsHostGame { get; }

        void CreateNewLobby();

        void ConnectToLobby();

        void CreateNewNetworkObject<TComponent>(TComponent prefab) where TComponent : MonoBehaviour;
    }
}