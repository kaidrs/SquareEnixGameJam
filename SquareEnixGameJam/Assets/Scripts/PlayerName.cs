using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class PlayerName : MonoBehaviour
{
    #region Singleton
    private static PlayerName _instance = null;
    public static PlayerName Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerName>();
            }
            return _instance;
        }
    }
    #endregion
    [SerializeField] private Text playersNames;
    [SerializeField] private Text playerHP;
    [SerializeField] private Text playerName;
    // Start is called before the first frame update
    public void UpdateNames()
    {
        //playerName.text = $"\nYou: {NetworkManager.Instance.myPlayer}";
        playersNames.text = "";
        foreach (var player in NetworkManager.Instance.thePs)
        {
            playersNames.text += $"\n{player}";
        }
    }
}
