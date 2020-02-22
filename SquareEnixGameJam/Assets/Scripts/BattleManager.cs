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
        //Hero thief = ScriptableObject.CreateInstance<Thief>();
        //thief.HealthPoint = 1.0f;
        //thief.AttackPoint = 5;
        //thief.DefencePoint = 5;
        //thief.Luck = 10;
        //thief.ClassText = "Thief";
        //Hero warrior = ScriptableObject.CreateInstance<Warrior>();
        //warrior.HealthPoint = 1.0f;
        //warrior.AttackPoint = 5;
        //warrior.DefencePoint = 5;
        //warrior.Luck = 10;
        //PlayerVsPlayer(thief, warrior);


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
        while (playerOne.healthPoint >= 0 || playerTwo.healthPoint >= 0);

        if(playerOne.healthPoint <= 0)
        {
            Debug.Log("Player two wins");
        }
        else
        {
            Debug.Log("Player one wins");
        }
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
