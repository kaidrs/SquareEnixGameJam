using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    [SerializeField] private List<Player> players;

    private int MAX_PLAYERS = 6;
    private int MIN_PLAYERS = 2;


    #region Singleton
    private static GameManager _instance = null;

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

    /// <summary>
    /// When player is first connected via Photon, add player to players list
    /// </summary>
    /// <param name="player"></param>
    void AddPlayer(Player player)
    {
        if (players.Count < MAX_PLAYERS)
        {
            players.Add(player);
        } else
        {
            print("Number of players is maximum. Cannot add more players");
        }
    }

    void StartGame()
    {
        if (players.Count > MIN_PLAYERS)
        {
            print("Starting game...");
        }
    }

    /// <summary>
    /// For DiceManager
    /// </summary>
    /// <param name="player"></param>
    /// <param name="order"></param>
    void RegisterTurn(Player player, int order)
    {
        player.Turn = order;
    }
}
