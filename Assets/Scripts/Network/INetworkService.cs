using System;
using Base;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Network
{
    public interface INetworkService : IService
    {
        IObservable<Unit> OnConnected { get; }
        bool IsHostGame { get; }

        UniTask CreateNewLobby();

        UniTask ConnectToLobby();

        void CreateNewNetworkObject<TComponent>(TComponent prefab) where TComponent : MonoBehaviour;
    }
}