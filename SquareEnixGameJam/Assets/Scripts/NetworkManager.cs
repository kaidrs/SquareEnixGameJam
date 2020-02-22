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
    public string playersNames;
    PhotonView photonView;
    public Photon.Realtime.Player myPunPlayer;
    //public List<Player> thePlayers;
    //public Player myPlayer;
    PlayerManager PMi;
    private void Awake()
    {
        #region Dont Destroy On Load
        var objects = FindObjectsOfType(this.GetType());
        if (objects.Length > 1)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        #endregion

        myPunPlayer = PhotonNetwork.LocalPlayer;
        //thePlayers = new List<Player>();

        UpdatePunPlayersName();
        //thePlayer = new ThePlayer(myPlayer.ToString(), UnityEngine.Random.Range(10, 200), UnityEngine.Random.Range(101, 160));
        //PlayerName.Instance.UpdateNames();
        PMi = PlayerManager.Instance;
        PMi.Init();
    }

    private void UpdatePunPlayersName()
    {
        playersNames = "";
        foreach (var player in PhotonNetwork.PlayerList)
        {
            playersNames += $"\n{player.NickName}";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        photonView.RPC("ReceiveMyPlayerJSON", RpcTarget.Others, myPlayerJSONEcoded(PMi.currentPlayer));
        //photonView.RPC("UpdateThePs", RpcTarget.AllViaServer, myPlayerJSONEcoded(myPlayer));
    }

    private string myPlayerJSONEcoded(Player playerToEncode)
    {
        return JsonUtility.ToJson(playerToEncode);
    }

    private static Player myPlayerJSONDecoded(string playerJSON)
    {
        return (Player)JsonUtility.FromJson(playerJSON, typeof(Player));
    }

    public void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log(newPlayer.NickName);
        UpdatePunPlayersName();
        //photonView.RPC("ReceiveMyPlayerJSON", RpcTarget.Others, myPlayerJSONEcoded(PMi.currentPlayer));
    }

    public void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Player player = null;
        for (int i = 0; i < PMi.allPlayers.Count; i++)
        {
            if (PMi.allPlayers[i].punName == otherPlayer.ToString())
            {
                player = PMi.allPlayers[i];
                break;
            }
        }
        if (player != null)
        {
            PMi.allPlayers.Remove(player);
        }

        UpdatePunPlayersName();
    }

    public void SortPlayers()
    {
        PMi.allPlayers.Sort();
    }

    //public void Attack()
    //{
    //    int randIndex = Random.Range(0, thePlayers.Count);
    //    var randPlayer = thePlayers[randIndex];
    //    randPlayer.HP -= 10;
    //    Debug.Log($"Attacks");
    //    photonView.RPC("UpdateThePs", RpcTarget.AllViaServer, myPlayerJSONEcoded(randPlayer));
    //}

    [PunRPC]
    public void UpdateThePs(string playerJSON, PhotonMessageInfo info)
    {
        var player = myPlayerJSONDecoded(playerJSON);
        for (int i = 0; i < PMi.allPlayers.Count; i++)
        {
            if (PMi.allPlayers[i].punName == player.punName)
            {
                PMi.allPlayers[i] = player;
                break;
            }
        }
    }

    [PunRPC]
    public void ReceiveMyPlayerJSON(string playerJSON, PhotonMessageInfo info)
    {
        Player playerJSONDecode = myPlayerJSONDecoded(playerJSON);
        if (!PMi.allPlayers.Exists(x => x.punName == playerJSONDecode.punName))
        {
            PMi.allPlayers.Add(playerJSONDecode);
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

    public void Ready()
    {
        PMi.currentPlayer.punReady = true;
        photonView.RPC("UpdateThePs", RpcTarget.AllViaServer, myPlayerJSONEcoded(PMi.currentPlayer));
        if (!PMi.allPlayers.Exists(x => !x.punReady))
        {
            PhotonNetwork.LoadLevel("PlayScene");
        }
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
