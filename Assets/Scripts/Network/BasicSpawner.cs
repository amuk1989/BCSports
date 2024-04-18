﻿using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Fusion;
using Fusion.Photon.Realtime;
using Fusion.Sockets;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Network
{
    internal class BasicSpawner : MonoBehaviour, INetworkRunnerCallbacks
    {
        [SerializeField] private NetworkRunner _runner;

        private readonly ReactiveCommand _onConnected = new();

        public IObservable<Unit> OnConnectedAsRx => _onConnected.AsObservable();

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
            if (!runner.IsServer) return;
            Debug.Log("OnPlayerJoined");
            _onConnected.Execute();
            PlayerRef = player;
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
            Debug.Log("OnConnectedToServer");
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
            // Create the Fusion runner and let it know that we will be providing user input
            _runner.ProvideInput = true;

            // Create the NetworkSceneInfo from the current scene
            var scene = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex);
            var sceneInfo = new NetworkSceneInfo();
            if (scene.IsValid) sceneInfo.AddSceneRef(scene, LoadSceneMode.Additive);

            // Start or join (depends on gamemode) a session with a specific name
            var result = await _runner.StartGame(new StartGameArgs
            {
                GameMode = mode,
                SessionName = "TestRoom",
                Scene = scene,
                MatchmakingMode = MatchmakingMode.FillRoom,
                IsOpen = true,
                IsVisible = true,
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
            });

            return result.Ok;
        }
    }
}