using Fusion;
using UnityEngine;
using Zenject;

namespace Network
{
    internal class NetworkObjectFactory
    {
        private readonly BasicSpawner _basicSpawner;

        private NetworkObjectFactory(BasicSpawner basicSpawner)
        {
            _basicSpawner = basicSpawner;
        }

        public TComponent Create<TComponent>(TComponent prefab, Transform parent, Vector3 position, PlayerRef playerRef)
            where TComponent : NetworkBehaviour
        {
             var result = _basicSpawner
                .NetworkRunner
                .SpawnAsync(prefab.gameObject, position, Quaternion.identity, playerRef);

             return result.Object.gameObject.GetComponent<TComponent>();
        }

        public void Destroy(NetworkObject networkObject)
        {
            _basicSpawner.NetworkRunner.Despawn(networkObject);
        }
    }
}