using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Name the player registers with
    [SerializeField] private string displayName;

    // Turn order of the player. Starts with 1, end with GameManager.players.Count
    private int turn;

    // TODO: Add this field when @Robert is done with Hero class
    // [SerializeField] Hero character;

    public Player(string displayName)
    {
        this.displayName = displayName;
    }

    public Player() {}

}
