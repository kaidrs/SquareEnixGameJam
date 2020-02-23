using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    //[SerializeField] private List<Player> players;

    private int MAX_PLAYERS = 6;
    private int MIN_PLAYERS = 2;

    //public List<Player> Players { get => PlayerManager.Instance.allPlayers; }

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
    }


    public void StartGame()
    {
        PlayerManager.Instance.SetReadyToFalse();
        NetworkManager.Instance.BroadcastUpdateTurn();
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
