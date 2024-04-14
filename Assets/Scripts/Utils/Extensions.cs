using Base;
using Zenject;

namespace Utils
{
    public static class Extensions
    {
        public static void InstallService<TInterface, TService>(this DiContainer container)
            where TService : class, TInterface
            where TInterface : IService
        {
            container
                .Bind<TInterface>()
                .To<TService>()
                .AsSingle()
                .NonLazy();
        }
    }
}