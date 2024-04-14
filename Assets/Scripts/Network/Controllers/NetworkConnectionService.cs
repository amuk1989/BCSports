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
            throw new NotImplementedException();
        }

        public void OnDisconnected(DisconnectCause cause)
        {
            throw new NotImplementedException();
        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {
            throw new NotImplementedException();
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
            throw new NotImplementedException();
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
            throw new NotImplementedException();
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