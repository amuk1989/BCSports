using Utils;
using Zenject;

namespace Network
{
    public class NetworkInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.InstallService<INetworkService, NetworkService>();
        }
    }
}