using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    private static PlayerManager _instance = null;

    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerManager>();
            }
            return _instance;
        }
    }
    #endregion

    public List<Player> allPlayers;
    public Player ownerPlayer;

    public bool IsCurrent = false;

    void Awake()
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
    }

    public void Init()
    {
        allPlayers = new List<Player>();
        ownerPlayer = new Player(NetworkManager.Instance.myPunPlayer.NickName, NetworkManager.Instance.myPunPlayer.ToString());
        ownerPlayer.turn = Random.Range(0, 100);
        Debug.Log($"muPunPlayer {NetworkManager.Instance.myPunPlayer.ToString()}");
    }

    public void BroadcastUpdate()
    {
        UpdateMyP();
        NetworkManager.Instance.photonView.RPC("UpdateThePs", RpcTarget.AllViaServer, NetworkManager.Instance.myPlayerJSONEcoded(ownerPlayer));
    }

    public void UpdateMyP()
    {
        for (int i = 0; i < allPlayers.Count; i++)
        {
            if (allPlayers[i].punName == ownerPlayer.punName)
            {
                allPlayers[i] = ownerPlayer;
                break;
            }
        }
    }
}
