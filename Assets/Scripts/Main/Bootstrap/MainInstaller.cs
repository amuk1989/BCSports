using GameStage.Bootstrap;
using Network;
using Rules;
using UI.Bootstrap;
using Zenject;

namespace Main.Bootstrap
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Install<GameStageInstaller>();
            Container.Install<NetworkInstaller>();
            Container.Install<UIInstaller>();
            Container.Install<RulesInstaller>();
        }
    }
}