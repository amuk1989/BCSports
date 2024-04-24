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

        public void Create<TComponent>(TComponent prefab, Transform parent, Vector3 position)
            where TComponent : MonoBehaviour
        {
            _basicSpawner.NetworkRunner.SpawnAsync(prefab.gameObject, position, Quaternion.identity,
                _basicSpawner.PlayerRef);
        }
    }
}