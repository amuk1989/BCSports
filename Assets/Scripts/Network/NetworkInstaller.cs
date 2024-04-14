using Utils;
using Zenject;

namespace Network
{
    public class NetworkInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.InstallService<INetworkService, NetworkService>();
            Container
                .Bind<NetworkLobbyService>()
                .AsSingle()
                .Lazy();
            Container
                .Bind<NetworkConnectionService>()
                .AsSingle()
                .Lazy();
        }
    }
}