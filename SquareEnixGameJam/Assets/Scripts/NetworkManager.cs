using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class NetworkManager : MonoBehaviour, IInRoomCallbacks
{
    #region Singleton
    private static NetworkManager _instance = null;
    public static NetworkManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<NetworkManager>();
            }
            return _instance;
        }
    }
    #endregion

    public List<Photon.Realtime.Player> photonPlayers;
    public Photon.Realtime.Player myPlayer;

    private void Awake()
    {
        photonPlayers = new List<Photon.Realtime.Player>();

        foreach (var player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            if (player == PhotonNetwork.LocalPlayer)
            {
                myPlayer = PhotonNetwork.LocalPlayer;
            }
            else
            {
                photonPlayers.Add(player);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPlayerEnteredRoom(Player newPlayer)
    {
        
    }

    public void OnPlayerLeftRoom(Player otherPlayer)
    {
    }

    public void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
    }

    public void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
    }

    public void OnMasterClientSwitched(Player newMasterClient)
    {
    }

    public void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        throw new System.NotImplementedException();
    }

    public void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        throw new System.NotImplementedException();
    }

    public void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        throw new System.NotImplementedException();
    }

    public void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
    {
        throw new System.NotImplementedException();
    }
}
