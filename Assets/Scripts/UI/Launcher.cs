﻿using System;
using System.Collections.Generic;
using Network;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class Launcher : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _createLobby;
        [SerializeField] private Transform _lobbyItemsHandler;

        private INetworkService _networkService;
        private LobbyItem.Factory _itemFactory;

        [Inject]
        private void Construct(INetworkService networkService, LobbyItem.Factory factory)
        {
            _networkService = networkService;
            _itemFactory = factory;
        }

        private void Start()
        {
            _startButton
                .OnClickAsObservable()
                .Subscribe(_ => OnStartClick())
                .AddTo(this);

            _createLobby
                .OnClickAsObservable()
                .Subscribe(_ => _networkService.CreateNewLobby())
                .AddTo(this);

            _createLobby.enabled = false;
        }

        private void OnStartClick()
        {
            _networkService.Initialize();
            _createLobby.enabled = true;
            _networkService.OnRoomListUpdated
                .Subscribe(_ => OnRoomsListUpdated())
                .AddTo(this);
        }

        private void OnRoomsListUpdated()
        {
            foreach (var roomInfo in _networkService.Rooms) _itemFactory.Create(roomInfo.Name, _lobbyItemsHandler);
        }
    }
}