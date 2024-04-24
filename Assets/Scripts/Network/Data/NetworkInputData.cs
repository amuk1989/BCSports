using Fusion;
using UnityEngine;

namespace Network.Data
{
    public struct NetworkInputData : INetworkInput
    {
        public readonly Vector2 Direction;

        public NetworkInputData(Vector2 direction)
        {
            Direction = direction;
        }
    }
}