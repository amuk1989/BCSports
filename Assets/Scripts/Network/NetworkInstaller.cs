using Utils;
using Zenject;

namespace Network
{
    public class NetworkInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.InstallService<INetworkService, NetworkService>();

            Container.Bind<BasicSpawner>()
                .FromComponentInNewPrefabResource("Prefabs/BasicSpawner")
                .AsSingle()
                .Lazy();

            Container
                .Bind<NetworkObjectFactory>()
                .AsSingle()
                .Lazy();
        }
    }
}