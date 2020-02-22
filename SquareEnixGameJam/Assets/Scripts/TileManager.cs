using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    None, Loot, Spell, Monster
}

public enum ZoneType
{
    StarterZone, MiddleZone, FinalZone
}

[Serializable]
public class Zone
{
    public string name;
    [SerializeField] private ZoneType type;
    [SerializeField] private List<TileType> numberOfTiles;
    private float zoneMultiplier = 1.0f;

    public float GetZoneMultiplier()
    {
        switch(type)
        {
            case ZoneType.StarterZone:
                return zoneMultiplier = 1.0f;
            case ZoneType.MiddleZone:
                return zoneMultiplier = 1.5f;
            case ZoneType.FinalZone:
                return zoneMultiplier = 2.0f;
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
            if(_instance == null)
            {
                _instance = FindObjectOfType<TileManager>();
            }
            return _instance;
        }
    }
    #endregion

    //Need player class here
    [SerializeField] private List<Zone> numberOfZones;
    private int playerTileLocation;

    void Start()
    {
        this.playerTileLocation = 0;

        //find Object of Type Player
    }

    /// <summary>
    /// Moves the player tile location according to the dice value
    /// </summary>
    /// <param name="diceValue"></param>
    public void SetPlayerTileLocation(int diceValue)
    {
        this.playerTileLocation += diceValue;
    }

    public void PromptCardTile()
    {
        //Scene change which depends on the event
    }
}
