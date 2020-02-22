using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Name the player registers with
    [SerializeField] private string displayName;

    // Turn order of the player. Starts with 1, end with GameManager.players.Count
    private int turn;
    private int tilePosition; //stores tile position 
    private ZoneType zone;

    // The character player chooses at the beginning
    [SerializeField] Hero character;

    public int Turn { get => turn; set => turn = value; }
    public int TilePosition { get => tilePosition; set => TilePosition = value; }
    public ZoneType Zone { get => zone; set => Zone = value; }
    public string DisplayName { get => displayName; set => displayName = value; }
    public Hero Character { get => character; set => character = value; }

    public Player(string displayName)
    {
        this.displayName = displayName;
        this.tilePosition = 0;
        this.zone = ZoneType.StarterZone;
    }

    public Player() { }

}
