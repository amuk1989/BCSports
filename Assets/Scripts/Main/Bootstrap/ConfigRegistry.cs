using Camera.Configs;
using GameStage.Controllers;
using Gun;
using Input.Configs;
using UnityEngine;
using Utils;
using Zenject;

namespace Main.Bootstrap
{
    [CreateAssetMenu(fileName = "ConfigRegistry", menuName = "Registries/ConfigRegistry", order = 0)]
    public class ConfigRegistry : ScriptableObjectInstaller
    {
        [SerializeField] private GameStageConfig _gameStageConfig;
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private InputConfig _inputConfig;
        [SerializeField] private CameraConfig _cameraConfig;
        
        public override void InstallBindings()
        {
            Container.InstallRegistry(_gameStageConfig.Data);
            Container.InstallRegistry(_gameConfig.Data);
            Container.InstallRegistry(_inputConfig.Data);
            Container.InstallRegistry(_cameraConfig.Data);
        }
    }
}