using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour

{


    #region Singleton
    private static GameManager _instance = null;
    private int currentTurn;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    #endregion

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

    public int randomCardTap = 0;
    public void UpdateTurn()
    {

        int next = currentTurn + 1;
        currentTurn = next > PlayerManager.Instance.allPlayers.Count ? next - PlayerManager.Instance.allPlayers.Count : next;
        if (PlayerManager.Instance.allPlayers[currentTurn - 1].punName == PlayerManager.Instance.ownerPlayer.punName)
        {
            PlayerManager.Instance.IsCurrent = true;
        }
        else
        {
            PlayerManager.Instance.IsCurrent = false;
        }
        Debug.Log("current " + currentTurn);
        UIManager.Instance?.EnableTurn();
        Debug.Log(UIManager.Instance);
    }


    public void StartGame()
    {
        PlayerManager.Instance.SetReadyToFalse();
        if (PhotonNetwork.PlayerList[0] == NetworkManager.Instance.myPunPlayer)
        {
            
            NetworkManager.Instance.BroadcastUpdateTurn(); 
        }
        Debug.Log("StartGAME!!!");
    }

    /// <summary>
    /// For DiceManager
    /// </summary>
    /// <param name="player"></param>
    /// <param name="order"></param>
    void RegisterTurn(Player player, int order)
    {
        player.turn = order;
    }

}
