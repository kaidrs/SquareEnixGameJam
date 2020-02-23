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
    public PhotonView photonView;
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
        photonView.RPC("ReceiveMyPlayerJSON", RpcTarget.AllViaServer, myPlayerJSONEcoded(PMi.ownerPlayer));
        //photonView.RPC("UpdateThePs", RpcTarget.AllViaServer, myPlayerJSONEcoded(myPlayer));
    }

    public string myPlayerJSONEcoded(Player playerToEncode)
    {
        return JsonUtility.ToJson(playerToEncode);
    }

    public static Player myPlayerJSONDecoded(string playerJSON)
    {
        return (Player)JsonUtility.FromJson(playerJSON, typeof(Player));
    }

    public void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log(newPlayer.NickName);
        UpdatePunPlayersName();
        photonView.RPC("ReceiveMyPlayerJSON", RpcTarget.Others, myPlayerJSONEcoded(PMi.ownerPlayer));
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
        Debug.Log($"Add to PLayer list! {playerJSON}");
        var player = myPlayerJSONDecoded(playerJSON);
        Debug.Log($"PLayer {player}");
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
        Debug.Log($"Add to PLayer list! {playerJSON}");
        Player playerJSONDecode = myPlayerJSONDecoded(playerJSON);
        Debug.Log($"PLayer {playerJSONDecode}");
        if (!PMi.allPlayers.Exists(x => x.punName == playerJSONDecode.punName))
        {
            PMi.allPlayers.Add(playerJSONDecode);
        }
    }

    [PunRPC]
    public void LoadScene(string sceneName, PhotonMessageInfo info)
    {
        PhotonNetwork.LoadLevel(sceneName);
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
        PMi.ownerPlayer.punReady = true;
        PMi.BroadcastUpdate();
        if (!PMi.allPlayers.Exists(x => !x.punReady))
        {
            var sceneName = "PlayScene";
            photonView.RPC("LoadScene", RpcTarget.AllViaServer, sceneName);
        }
        foreach (var item in PMi.allPlayers)
        {
            Debug.Log($"{item} - {item.punReady}");
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
