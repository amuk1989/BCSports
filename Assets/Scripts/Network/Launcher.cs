using System;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace Network
{
    public class Launcher : MonoBehaviour
    {
        private readonly string _gameVersion = "1";

        [Inject] private INetworkService _networkService;

        private void Start()
        {
            _networkService.Initialize();
        }
    }
}