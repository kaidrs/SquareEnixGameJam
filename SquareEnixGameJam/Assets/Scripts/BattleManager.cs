using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region Singleton
    private static BattleManager _instance = null;

    public static BattleManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<BattleManager>();
            }
            return _instance;
        }
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerVsPlayer(Hero playerOne, Hero playerTwo)
    {
        do
        {
                playerOne.TakeDamageFromPlayer(playerTwo);
                playerTwo.TakeDamageFromPlayer(playerOne);
        }
        while (playerOne.HealthPoint >= 0 || playerTwo.HealthPoint >= 0);
    }


}
