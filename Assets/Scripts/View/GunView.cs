using Fusion;
using Network.Data;
using UnityEngine;
using Zenject;

namespace View
{
    public class GunView : NetworkBehaviour
    {
        [SerializeField] private NetworkCharacterController _cc;

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData data))
            {
                Debug.Log(data.Direction);
                transform.position += (Vector3)data.Direction * 0.01f;
            }
        }
    }
}