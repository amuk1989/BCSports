﻿using Fusion;
using UnityEngine;
using Zenject;

namespace Network
{
    internal class NetworkObjectFactory
    {
        private readonly BasicSpawner _basicSpawner;
        private readonly DiContainer _diContainer;

        private NetworkObjectFactory(BasicSpawner basicSpawner, DiContainer diContainer)
        {
            _basicSpawner = basicSpawner;
            _diContainer = diContainer;
        }

        public TComponent Create<TComponent>(TComponent prefab, Transform parent, Vector3 position, PlayerRef playerRef)
            where TComponent : NetworkBehaviour
        {
            var result = _basicSpawner
                .NetworkRunner
                .Spawn(prefab.gameObject, position, Quaternion.identity, playerRef);

            var component = result.GetComponent<TComponent>();

            _diContainer.Inject(component);
            component.enabled = true;

            return component;
        }

        public void Destroy(NetworkObject networkObject)
        {
            _basicSpawner.NetworkRunner.Despawn(networkObject);
        }
    }
}