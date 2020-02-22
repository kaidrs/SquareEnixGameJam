using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Name the player registers with
    [SerializeField] private string displayName;

    // Turn order of the player. Starts with 1, end with GameManager.players.Count
    private int turn;

    // The character player chooses at the beginning
    [SerializeField] Hero character;

    public int Turn { get => turn; set => turn = value; }
    public string DisplayName { get => displayName; set => displayName = value; }
    public Hero Character { get => character; set => character = value; }

    public Player(string displayName)
    {
        this.displayName = displayName;
    }

    public Player() {}

}
