using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    None, Loot, Spell, Monster, Checkpoint, MonsterBoss
}

[Serializable]
public enum ZoneType
{
    StarterZone, MiddleZone, FinalZone
}

[Serializable] //The Game Board will be set and modifiable in the editor
public class Zone
{
    public string name;
    [SerializeField] private ZoneType type;
    [SerializeField] private List<TileType> tiles;
    private float zoneMultiplier;

    public List<TileType> Tiles { get => tiles; set => Tiles = value; }
    public float ZoneMultiplier { get => zoneMultiplier; set => ZoneMultiplier = value; }
    public ZoneType Type { get => type; set => Type = value; }

    /// <summary>
    /// Retrieves zone multipliers
    /// </summary>
    /// <returns></returns>
    public float GetZoneMultiplier()
    {
        switch (type)
        {
            case ZoneType.StarterZone:
                return this.zoneMultiplier = 1.0f;
            case ZoneType.MiddleZone:
                return this.zoneMultiplier = 1.5f;
            case ZoneType.FinalZone:
                return this.zoneMultiplier = 2.0f;
            default:
                return 0;
        }
    }
}

public class TileManager : MonoBehaviour
{
    #region TileManager Singleton
    private static TileManager _instance = null;
    public static TileManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TileManager>();
            }
            return _instance;
        }
    }
    #endregion

    [SerializeField] private List<Zone> zones;
    private List<Player> playerList;
    private Player currentActivePlayer;
    private int currentTurn = 1;
    public List<TileType> board;


    public void Start()
    {
        board = new List<TileType>();
        Debug.Log($"Set {zones.Count} Zones in Board");


        foreach (var zone in zones)
        {
            foreach (var tile in zone.Tiles)
            {
                board.Add(tile);

            }
        }
    }

    public void RetrievePlayerList()
    {
        if (GameManager.Instance.Players != null)
        {
            playerList = GameManager.Instance.Players; //retrieve the list of players set in GameManager

            playerList.Sort(SortByTurn);
        }
    }

    public int SortByTurn(Player p1, Player p2)
    {
        return p1.turn.CompareTo(p2.turn);
    }


    public void UpdateTurn()
    {
        int next = currentTurn + 1;
        currentTurn = next > playerList.Count ? next - playerList.Count : next;
        currentActivePlayer = playerList[currentTurn - 1];
        Debug.Log("current " + currentTurn);
    }


    /// <summary>
    /// Moves the player tile location according to the dice value
    /// </summary>
    /// <param name="diceValue"></param>
    public void SetPlayerTilePosition(int diceValue)
    {
        int nextPosition = currentActivePlayer.tilePosition + diceValue;
        int lastTile = board.Count - 1;

        if (nextPosition > (lastTile - currentActivePlayer.tilePosition))
        {
            currentActivePlayer.tilePosition = lastTile;
        }
        else
        {
            currentActivePlayer.tilePosition = nextPosition;
        }

        UpdatePlayerZone();
    }

    public void UpdatePlayerZone()
    {
        for (int i = 0; i < zones.Count; i++)
        {
            if (currentActivePlayer.tilePosition < zones[i].Tiles.Count)
            {
                currentActivePlayer.zone = zones[i].Type;
                break;
            }
        }
    }

    public void PromptCardTile() //to refactor in accordance to card manager
    {
        int cardID = 1; //to be removed
        CardManager.Instance.CallCard(cardID);
        //UI/Scene change which depends on the event
    }

    public void VerifyPlayerTilePosition()
    {

    }
}
