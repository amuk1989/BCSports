using System;
using Base;
using Cysharp.Threading.Tasks;
using Fusion;
using Network.Data;
using UniRx;
using UnityEngine;

namespace Network
{
    public interface INetworkService : IService
    {
        IObservable<PlayerRef> OnConnected { get; }

        PlayerRef LocalPlayer { get; }

        bool IsHostGame { get; }

        UniTask CreateNewLobby();

        UniTask ConnectToLobby();

        void CreateNewNetworkObject<TComponent>(TComponent prefab, PlayerRef playerRef)
            where TComponent : MonoBehaviour;

        void SetNetworkInput(NetworkInputData networkInputData);
    }
}