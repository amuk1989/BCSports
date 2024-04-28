using System;
using Base.Interfaces;
using Camera.Interfaces;
using Fusion;
using Network.Data;
using UnityEngine;
using Zenject;

namespace View
{
    public class NetworkComponent : NetworkBehaviour
    {
        [SerializeField] private NetworkCharacterController _cc;

        private SignalBus _signalBus;
        private ICameraService _cameraService;

        [Inject]
        private void Construct(SignalBus signalBus, ICameraService cameraService)
        {
            _signalBus = signalBus;
            _cameraService = cameraService;
        }

        private void Start()
        {
            _cameraService.LookAt(transform.position);
        }

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData data))
            {
                Debug.Log(data.Direction);
                _cameraService.RotateAroundTarget(data.Direction);
            }
        }
    }
}