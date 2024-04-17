using UnityEngine;
using Zenject;

namespace View
{
    public class GunView : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<Vector3, GunView>
        {
        }
    }
}