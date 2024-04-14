using System;
using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Network
{
    internal class NetworkRoomService : IInRoomCallbacks
    {
        public void OnPlayerEnteredRoom(Player newPlayer)
        {
            throw new NotImplementedException();
        }

        public void OnPlayerLeftRoom(Player otherPlayer)
        {
            throw new NotImplementedException();
        }

        public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            throw new NotImplementedException();
        }

        public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            throw new NotImplementedException();
        }

        public void OnMasterClientSwitched(Player newMasterClient)
        {
            throw new NotImplementedException();
        }
    }
}