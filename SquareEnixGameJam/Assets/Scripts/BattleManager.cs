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
        Hero thief = new Thief(1.0f, 5, 5, 10, "Thief");  
        Hero warrior = new Warrior(1.0f, 10, 5, 5, "Warrior");

        PlayerVsPlayer(thief, warrior);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerVsPlayer(Hero playerOne, Hero playerTwo)
    {
        playerOne.TakeDamageFromPlayer(playerTwo);
        playerTwo.TakeDamageFromPlayer(playerOne);
        Debug.Log(playerOne.HealthPoint);
        Debug.Log(playerTwo.HealthPoint);

    }


    public void PlayerVsMonster(Hero player, MonsterCard monster)
    {
        do
        {
            monster.TakeDamage(player);
            player.TakeDamageFromMonster(monster);
        }
        while (player.healthPoint >= 0 || monster.Health >= 0);
    }


}
