using Network;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LobbyItem : MonoBehaviour, IPoolable<string, Transform, IMemoryPool>
    {
        public class Factory : PlaceholderFactory<string, Transform, LobbyItem>
        {
        }
        
        [SerializeField] private Button _connectButton;
        [SerializeField] private TMP_Text _nameText;

        private INetworkService _networkService;

        [Inject]
        private void Construct(INetworkService networkService)
        {
            _networkService = _networkService;
        }

        public void OnDespawned()
        {
            
        }

        public void OnSpawned(string lobbyName, Transform parent, IMemoryPool _)
        {
            transform.SetParent(parent);
            _nameText.text = lobbyName;
        }
    }
}