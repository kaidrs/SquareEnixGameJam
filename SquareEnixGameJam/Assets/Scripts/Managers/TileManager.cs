using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    None, Event, Loot, Spell, Monster, Checkpoint, MonsterBoss
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
    PlayerManager PMi;
    DiceManager DMi;
    [SerializeField] GameObject panelBattle;

    private void Awake()
    {
        PMi = PlayerManager.Instance;
        DMi = DiceManager.Instance;
    }

    public void Start()
    {
        board = new List<TileType>();
        Debug.Log($"Set {zones.Count} Zones in Board");
      //  TestBattle();

        foreach (var zone in zones)
        {
            foreach (var tile in zone.Tiles)
            {
                board.Add(tile);

            }
        }
    }

    public TileType GetMyCurrentTile(int tilePosition)
    {
        return board[tilePosition];
    }
    //public void RetrievePlayerList()
    //{
    //    if (GameManager.Instance.Players != null)
    //    {
    //        playerList = GameManager.Instance.Players; //retrieve the list of players set in GameManager

    //        playerList.Sort(SortByTurn);
    //    }
    //}

    public int SortByTurn(Player p1, Player p2)
    {
        return p1.turn.CompareTo(p2.turn);
    }

    /// <summary>
    /// Moves the player tile location according to the dice value
    /// </summary>
    /// <param name="diceValue"></param>
    /// 
    public void SetPlayerTilePosition(int diceValue)
    {
        if (!PlayerManager.Instance.IsCurrent)
        {
            return;
        }
        int nextPosition = PlayerManager.Instance.ownerPlayer.tilePosition + diceValue;
        int lastTile = board.Count - 1;

        if (nextPosition > (lastTile - PlayerManager.Instance.ownerPlayer.tilePosition))
        {
            PlayerManager.Instance.ownerPlayer.tilePosition = lastTile;
        }
        else
        {
            PlayerManager.Instance.ownerPlayer.tilePosition = nextPosition;
        }
        UpdatePlayerZone();
        PlayerManager.Instance.BroadcastUpdate();
        if (GetMyCurrentTile(PMi.ownerPlayer.tilePosition)!= TileType.Checkpoint)
        {
            Player pvpHeroForBattle;
            foreach (var player in PMi.allPlayers)
            {
                if (player.punName != PMi.ownerPlayer.punName && player.tilePosition == PMi.ownerPlayer.tilePosition)
                {
                    pvpHeroForBattle = player;
                    UIManager.Instance.PromptBattle(PMi.ownerPlayer.hero, player.hero);
                    return;
                }
            } 
        }
        // call check tile postion and do aciton based postion
        UIManager.Instance.PromptMessage($"Move your peon by {diceValue}.");
        VerifyPlayerTilePosition();
    }


    public void TestBattle()
    {
        PMi.allPlayers.Add(PlayerManager.Instance.ownerPlayer);
        PMi.allPlayers.Add(new Player("allo", "bye"));
        

        PMi.ownerPlayer.tilePosition += 4;
        for (int i = 0; i < PMi.allPlayers.Count; i++)
        {
            //Debug.Log(PMi.allPlayers[i].tilePosition);
            if (PMi.ownerPlayer.tilePosition == PMi.allPlayers[i].tilePosition)
            {
                Debug.Log(PMi.ownerPlayer.tilePosition);
                Debug.Log(PMi.allPlayers[i].tilePosition);
                UIManager.Instance.PromptBattle(PMi.ownerPlayer.hero, PMi.allPlayers[i].hero);
            }
        }
        // PMi.ownerPlayer.tilePosition = 6;
        //UpdatePlayerZone();
        //PlayerManager.Instance.BroadcastUpdate();
    }




    public void UpdatePlayerZone()
    {
        for (int i = 0; i < zones.Count; i++)
        {
            if (PlayerManager.Instance.ownerPlayer.tilePosition < zones[i].Tiles.Count)
            {
                PlayerManager.Instance.ownerPlayer.zone = zones[i].Type;
                break;
            }
        }
    }

    public void PromptCardTile() //to refactor in accordance to card manager
    {
        int cardID = 1; //to be removed
        CardManager.Instance.CallCard(cardID);
        FindObjectOfType<QRDecodeTest>().Play(); //singleton if yolo
        //UI/Scene change which depends on the event
    }

    public void VerifyPlayerTilePosition()
    {
        switch (GetMyCurrentTile(PMi.ownerPlayer.tilePosition))
        {
            case TileType.None:
                NetworkManager.Instance.BroadcastUpdateTurn(); // Ends the turn

                break;
            case TileType.Event:
                NetworkManager.Instance.BroadcastUpdateTurn(); // Ends the turn
                break;
            case TileType.Loot:
                ///get card number QR SHOW QR PROMT!!!
                //QRPROMT()
                UIManager.Instance.PromptGoQR();
                break;
            case TileType.Spell:
                ///get card number QR SHOW QR PROMT!!!
                //int cardmnumber = QRPROMT()
                UIManager.Instance.PromptGoQR();
                break;
            case TileType.Monster:
                ///get card number QR SHOW QR PROMT!!!
                UIManager.Instance.PromptGoQR();
                break;
            case TileType.Checkpoint:
                // Nothing prompt relax;
                NetworkManager.Instance.BroadcastUpdateTurn(); // Ends the turn
                break;
            case TileType.MonsterBoss:
                MonsterCard bossCard = CardManager.Instance.GetBossCard();
                bool battleResult = BattleManager.Instance.PlayerVsMonster(PMi.ownerPlayer.hero, bossCard);
                if (battleResult)
                {
                    LootCard lootedCard = CardManager.Instance.GetRandomLoot();
                    UIManager.Instance.PromptReward(lootedCard);
                }
                NetworkManager.Instance.BroadcastUpdateTurn(); // Ends the turn
                break;
            default:
                break;
        }
    }
}
