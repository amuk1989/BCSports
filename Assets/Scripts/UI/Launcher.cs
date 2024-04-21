using Cysharp.Threading.Tasks;
using Network;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class Launcher : BaseUI
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _createLobby;
        [SerializeField] private Transform _lobbyItemsHandler;

        private INetworkService _networkService;

        [Inject]
        private void Construct(INetworkService networkService)
        {
            _networkService = networkService;
        }

        private void Start()
        {
            _startButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    _networkService.ConnectToLobby().Forget();
                    _startButton.interactable = false;
                    _createLobby.interactable = false;
                })
                .AddTo(this);

            _createLobby
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    _networkService.CreateNewLobby().Forget();
                    _startButton.interactable = false;
                    _createLobby.interactable = false;
                })
                .AddTo(this);
        }
    }
}