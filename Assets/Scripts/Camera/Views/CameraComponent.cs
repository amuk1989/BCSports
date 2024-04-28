using System;
using Camera.Models;
using UniRx;
using UnityEngine;
using Zenject;

namespace Camera.Views
{
    public class CameraComponent: MonoBehaviour, IDisposable
    {
        private CameraModel _cameraModel;
        
        [Inject]
        private void Construct(CameraModel cameraModel)
        {
            _cameraModel = cameraModel;
        }

        private void Awake()
        {
            _cameraModel.UpdateSightDirection(transform.forward);
            _cameraModel.UpdatePosition(transform.position);
        }

        private void Update()
        {
            transform.forward = _cameraModel.SightDirection;
            transform.SetPositionAndRotation(_cameraModel.Position, _cameraModel.Rotation);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}