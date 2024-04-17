using UnityEngine;
using Zenject;

namespace UI.Bootstrap
{
    public class UIInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container
                .Bind<UIComponent>()
                .FromComponentInNewPrefabResource("Prefabs/MainCanvas")
                .AsSingle()
                .NonLazy();

            Container
                .BindFactory<string, Transform, BaseUI, BaseUI.Factory>()
                .FromFactory<UIPrefabFactory>();

            Container
                .BindInterfacesTo<UIRule>()
                .AsSingle()
                .NonLazy();
        }
    }
}