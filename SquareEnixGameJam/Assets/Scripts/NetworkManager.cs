using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using Random = UnityEngine.Random;

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

    PhotonView photonView;
    public Photon.Realtime.Player myPlayer;
    public List<ThePlayer> thePlayers;
    public ThePlayer thePlayer;

    private void Awake()
    {
        myPlayer = PhotonNetwork.LocalPlayer;
        thePlayers = new List<ThePlayer>();
        thePlayer = new ThePlayer(myPlayer.ToString(), UnityEngine.Random.Range(10, 200), UnityEngine.Random.Range(101, 160));
        thePlayer.hero.spellID.Add(23);
        thePlayers.Add(thePlayer);
        PlayerName.Instance.UpdateNames();
    }
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        photonView.RPC("ReceiveMyPlayerJSON", RpcTarget.Others, myPlayerJSONEcoded(thePlayer));
        photonView.RPC("UpdateThePs", RpcTarget.AllViaServer, myPlayerJSONEcoded(thePlayer));
    }

    private string myPlayerJSONEcoded(ThePlayer playerToEncode)
    {
        return JsonUtility.ToJson(playerToEncode);
    }

    private static ThePlayer myPlayerJSONDecoded(string playerJSON)
    {
        return (ThePlayer)JsonUtility.FromJson(playerJSON, typeof(ThePlayer));
    }

    public void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log(newPlayer.NickName);
        photonView.RPC("ReceiveMyPlayerJSON", RpcTarget.Others, myPlayerJSONEcoded(thePlayer));
    }

    public void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        ThePlayer player = null;
        for (int i = 0; i < thePlayers.Count; i++)
        {
            if (thePlayers[i].name == otherPlayer.ToString())
            {
                player = thePlayers[i];
                break;
            }
        }
        if (player != null)
        {
            thePlayers.Remove(player);
        }
        
        PlayerName.Instance.UpdateNames();
    }
    public void SortPlayers()
    {
        thePlayers.Sort();
    }
    public void Attack()
    {
        int randIndex = Random.Range(0, thePlayers.Count);
        var randPlayer = thePlayers[randIndex];
        randPlayer.HP -= 10;
        Debug.Log($"Attacks");
        photonView.RPC("UpdateThePs", RpcTarget.AllViaServer, myPlayerJSONEcoded(randPlayer));
    }

    [PunRPC]
    public void UpdateThePs(string playerJSON, PhotonMessageInfo info)
    {
        var player = myPlayerJSONDecoded(playerJSON);
        for (int i = 0; i < thePlayers.Count; i++)
        {
            if (thePlayers[i].name == player.name)
            {
                thePlayers[i] = player;
                break;
            }
        }
        PlayerName.Instance.UpdateNames();
    }

    [PunRPC]
    public void ReceiveMyPlayerJSON(string playerJSON, PhotonMessageInfo info)
    {
        ThePlayer playerJSONDecode = myPlayerJSONDecoded(playerJSON);
        if (!thePlayers.Exists(x => x.name == playerJSONDecode.name))
        {
            thePlayers.Add(playerJSONDecode);
            PlayerName.Instance.UpdateNames();
        }
    }

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
    }
    public void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {

    }
    public void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
    {

    }
}
