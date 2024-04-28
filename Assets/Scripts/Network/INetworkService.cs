using System;
using Base;
using Cysharp.Threading.Tasks;
using Fusion;
using Network.Data;

namespace Network
{
    public interface INetworkService : IService
    {
        IObservable<PlayerRef> OnConnected { get; }

        IObservable<PlayerRef> OnDisconnected { get; }

        PlayerRef LocalPlayer { get; }

        bool IsHostGame { get; }

        UniTask CreateNewLobby();

        UniTask ConnectToLobby();

        void CreateNewNetworkObject<TComponent>(TComponent prefab, PlayerRef playerRef)
            where TComponent : NetworkBehaviour;

        void SetNetworkInput(NetworkInputData networkInputData);
    }
}