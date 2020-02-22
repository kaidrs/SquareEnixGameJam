using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Player: IComparable
{

    //PUN
    public string punName;
    public bool punReady = false;

    // Name the player registers with
    public string displayName;
    
    // Turn order of the player. Starts with 1, end with GameManager.players.Count
    public int turn;
    public int tilePosition; //stores tile position 
    public ZoneType zone;

    // The hero player chooses at the beginning
    public Hero hero;

    //public int turn { get => turn; set => turn = value; }
    //public int tilePosition { get => tilePosition; set => tilePosition = value; }
    //public ZoneType zone { get => zone; set => zone = value; }
    //public string displayName { get => displayName; set => displayName = value; }

    public Player(string displayName, string punName)
    {
        this.displayName = displayName;
        this.tilePosition = 0;
        this.zone = ZoneType.StarterZone;
    }

    public Player()
    {

    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        if (obj is Player otherPlayer)
        {
            return punName.CompareTo(otherPlayer.punName);
        }
        else
        {
            return -1;
        }
    }
    public override string ToString()
    {
        return displayName;
    }
}
