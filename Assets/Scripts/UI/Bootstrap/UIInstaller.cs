using UnityEngine;
using Zenject;

namespace UI.Bootstrap
{
    public class UIInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container
                .BindFactory<string, Transform, LobbyItem, LobbyItem.Factory>()
                .FromMonoPoolableMemoryPool(x => x.WithInitialSize(10)
                    .FromComponentInNewPrefabResource("Prefabs/LobbyItem"));
        }
    }
}