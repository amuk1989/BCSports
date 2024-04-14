using System;
using System.Collections.Generic;
using Base;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Network
{
    public class NetworkConnectionService : IConnectionCallbacks, IService
    {
        public void OnConnected()
        {
            Debug.Log("[NetworkConnectionService] On connected!");
        }

        public void OnConnectedToMaster()
        {
        }

        public void OnDisconnected(DisconnectCause cause)
        {
        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {
            
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
        }

        public void Initialize()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        public void Dispose()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }
    }
}