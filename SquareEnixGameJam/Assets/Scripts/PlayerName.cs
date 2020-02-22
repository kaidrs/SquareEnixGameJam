using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerName : MonoBehaviour
{
    [SerializeField] private Text playerNames;
    // Start is called before the first frame update
    void Start()
    {
        playerNames.text += $"\nYou: {NetworkManager.Instance.myPlayer}";
        foreach (var player in NetworkManager.Instance.photonPlayers)
        {
            playerNames.text += $"\n{player}";
        }
    }

}
