using Network;
using UnityEngine;
using Zenject;

namespace UI
{
    public class Launcher : MonoBehaviour
    {
        [Inject] private INetworkService _networkService;

        private void Start()
        {
            _networkService.Initialize();
        }
    }
}