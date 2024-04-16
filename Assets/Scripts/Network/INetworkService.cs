using Base;

namespace Network
{
    public interface INetworkService : IService
    {
        void CreateNewLobby();
        void ConnectToLobby();
    }
}