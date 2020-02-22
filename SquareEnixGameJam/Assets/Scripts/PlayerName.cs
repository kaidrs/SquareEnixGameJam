using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerName : MonoBehaviour
{
    [SerializeField] private Text playerNames;
    List<Photon.Realtime.Player> photonPlayers;
    // Start is called before the first frame update
    void Start()
    {
        
        foreach (var player in photonPlayers)
        {
            playerNames.text += "\n" + photonPlayers;
        }
    }

}
