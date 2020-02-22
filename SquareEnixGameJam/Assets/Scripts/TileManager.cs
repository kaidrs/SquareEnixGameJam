using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    None, Loot, Spell, Monster, Checkpoint, MonsterBoss
}

public enum ZoneType
{
    StarterZone, MiddleZone, FinalZone
}

[Serializable] //The Game Board will be set and modifiable in the editor
public class Zone
{
    public string name;
    [SerializeField] private ZoneType type;
    [SerializeField] private List<TileType> numberOfTiles;
    private float zoneMultiplier;
    private int numberOfTilesPerZone;

    public List<TileType> NumberOfTiles { get => numberOfTiles; set => NumberOfTiles = value; }
    public float ZoneMultiplier { get => zoneMultiplier; set => ZoneMultiplier = value; }
    public int NumberOfTilesPerZone { get => numberOfTilesPerZone; set => NumberOfTilesPerZone = value; }

    public Zone (int numberOfTilesPerZone)
    {
        this.numberOfTilesPerZone = 10;
    }

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

    [SerializeField] private List<Zone> numberOfZones;
    private List<Player> playerList;
    private Player currentActivePlayer;
    private Queue<int> currentTurn;

    //Store board number of zones and tiles it contains
    private int numberOfExistingZones = 0; //default value
    private int numberOfExistingTiles = 0; //default value

    public void Start()
    {
        numberOfExistingZones = gameObject.GetComponent<TileManager>().numberOfZones.Count;
        Console.WriteLine($"Set {numberOfExistingTiles} Zones in Board");

        //foreach (var zones in this.numberOfZones)
        //{
        //    numberOfExistingZones++;
        //    Console.WriteLine($"Set {numberOfExistingTiles} Zones in Board");
        //    foreach (var tiles in zones.NumberOfTiles)
        //    {
        //        numberOfExistingTiles++;
        //        Console.WriteLine($"Set {numberOfExistingTiles} Tiles in Board");
        //    }
        //}
    }

    public void RetrievePlayerList()
    {
        if (playerList == null)
        {
            playerList = GameManager.Instance.Players; //retrieve the list of players set in GameManager

            for (int i = 1; i <= playerList.Count; i++) //check how many players exist in the list of players, and queue up their turn, from 1 to number of players
            {
                currentTurn.Enqueue(i); //i = 1, so the game should start with player with turn=1 to be at the first in queue
            }
        }
    }

    /// <summary>
    /// Loops through the list of players to verify their turn value. Set 
    /// </summary>
    public void CheckTurn()
    {
        //Look through the playerList who is the next to play
        foreach (Player player in playerList)
        {
            if (player.Turn == currentTurn.Peek())
            {
                currentActivePlayer = player;
            }
        }
    }

    /// <summary>
    /// Should be called at the end of the round. Next player becomes the active player
    /// </summary>
    public void ChangePlayerTurn()
    {
        //Enqueue needs to happen first so we can easily take the playing player, and move them to the end of queue
        currentTurn.Enqueue(currentActivePlayer.Turn); //add back current active player to the end
        currentTurn.Dequeue(); //remove current active player from the top of the list

        //assign next player at the top of the queue to be active player
        CheckTurn();
    }

    /// <summary>
    /// Moves the player tile location according to the dice value
    /// </summary>
    /// <param name="diceValue"></param>
    public void SetPlayerTilePosition(int diceValue)
    {
        currentActivePlayer.TilePosition += diceValue;
        foreach (var zone in numberOfZones)
        {
            if (currentActivePlayer.TilePosition <= zone.NumberOfTiles.Count)
            {

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
