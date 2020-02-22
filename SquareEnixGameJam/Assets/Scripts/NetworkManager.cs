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
    PhotonView photonView;
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
    public List<TheP> thePs;
    public TheP thePlayer;

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
        thePs = new List<TheP>();
        thePlayer = new TheP(myPlayer.ToString(), Random.Range(10, 200));
        thePs.Add(thePlayer);
        PlayerName.Instance.UpdateNames();
    }
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        photonView.RPC("ReceiveTheP", RpcTarget.Others, thePlayer.name,thePlayer.HP);
        photonView.RPC("UpdateThePs", RpcTarget.AllViaServer, thePlayer.name, thePlayer.HP);
    }
    
    public void OnPlayerEnteredRoom(Player newPlayer)
    {
        
    }

    public void OnPlayerLeftRoom(Player otherPlayer)
    {

    }

    public void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        Debug.Log("OnRoomPropertiesUpdate");
    }

    public void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        Debug.Log($"OnPlayerPropertiesUpdate, {NetworkManager.Instance.myPlayer}, TP:{targetPlayer},{changedProps}");
    }

    public void OnMasterClientSwitched(Player newMasterClient)
    {

    }

    
    public void Attack()
    {
        thePlayer.HP -= 10;
        Debug.Log($"Attacks");
        photonView.RPC("UpdateThePs", RpcTarget.AllViaServer, thePlayer.name,thePlayer.HP);
    }

    [PunRPC]
    public void ReceiveTheP(string name, int hp, PhotonMessageInfo info)
    {
        var incP = new TheP(name, hp);
        thePs.Add(incP);
        Debug.Log(incP);
    }

    [PunRPC]
    public void UpdateThePs(string name, int hp, PhotonMessageInfo info)
    {
        foreach (var item in thePs)
        {
            if (name == item.name)
            {
                item.HP = hp;
            }
        }
        PlayerName.Instance.UpdateNames();
    }

}
