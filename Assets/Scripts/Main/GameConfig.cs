using System;
using Base.Data;
using Base.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using View;

namespace Gun
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig", order = 0)]
    public class GameConfig : BaseConfig<GameConfigData>
    {
    }

    [Serializable]
    public struct GameConfigData : IConfigData
    {
        [SerializeField] private NetworkComponent _networkComponent;

        public NetworkComponent NetworkComponent => _networkComponent;
    }
}