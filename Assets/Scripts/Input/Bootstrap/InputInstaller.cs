using Input.Interface;
using Input.Services;
using Utils;
using Zenject;

namespace Input.Bootstrap
{
    public class InputInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.InstallService<IInputService, InputService>();
        }
    }
}