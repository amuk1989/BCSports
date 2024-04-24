using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Fusion;
using Fusion.Photon.Realtime;
using Fusion.Sockets;
using Network.Data;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Network
{
    internal class BasicSpawner : MonoBehaviour, INetworkRunnerCallbacks
    {
        [SerializeField] private NetworkRunner _runner;

        private NetworkInputData _networkInputData;

        private readonly ReactiveCommand<PlayerRef> _onConnected = new();

        public IObservable<PlayerRef> OnConnectedAsRx => _onConnected.AsObservable();

        public NetworkRunner NetworkRunner => _runner;
        public PlayerRef PlayerRef { get; private set; }

        public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
            Debug.Log("OnObjectExitAOI");
        }

        public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
            Debug.Log("OnObjectEnterAOI");
        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            if (!_runner.IsServer) return;
            Debug.Log("OnPlayerJoined");
            PlayerRef = player;
            _onConnected.Execute(PlayerRef);
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            if (_networkInputData.Direction == default) return;
            input.Set(_networkInputData);
            _networkInputData = default;
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
            if (runner.IsServer) return;
            Debug.Log("OnConnectedToServer");

            PlayerRef = runner.LocalPlayer;
            _onConnected.Execute(runner.LocalPlayer);
        }

        public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
        {
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request,
            byte[] token)
        {
            Debug.Log("OnConnectRequest");
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key,
            ArraySegment<byte> data)
        {
        }

        public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
        {
        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {
        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {
        }

        public async UniTask<bool> TryStartGameAsync(GameMode mode)
        {
            _runner.ProvideInput = true;

            var startGameArgs = new StartGameArgs()
            {
                GameMode = mode,
                SessionName = "TestRoom"
            };

            // Start or join (depends on gamemode) a session with a specific name
            var result = await _runner.StartGame(startGameArgs);

            if (_runner.IsServer) _runner.LoadScene(SceneManager.GetActiveScene().name);

            return result.Ok;
        }

        public void SetInputData(NetworkInputData networkInputData)
        {
            _networkInputData = networkInputData;
        }
    }
}