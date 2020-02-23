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


    PlayerManager PMi;
    //[SerializeField] 

    private void Awake()
    {
        PMi = PlayerManager.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        Hero thief = new Thief(100.0f, 5, 5, 25, "Thief");  
        Hero warrior = new Warrior(100.0f, 25, 5, 5, "Warrior");
        MonsterCard monster = ScriptableObject.CreateInstance<MonsterCard>();
        monster.Attack = 5;
        monster.Defence = 2;
        monster.Health = 100.0f;

       // PlayerVsPlayer(thief, warrior);
       // PlayerVsMonster(thief, monster);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PlayerVsPlayer(Hero playerOne, Hero playerTwo)
    {
        if(PMi.ownerPlayer.hero.spellCards != null)
        {
            //Do you wanna use spell panel
        }
        while (playerOne.healthPoint >= 0.0f && playerTwo.healthPoint >= 0.0f)
        {
            playerTwo.TakeDamageFromPlayer(playerOne);
            playerOne.TakeDamageFromPlayer(playerTwo);
            Debug.Log("Player one " + playerOne.healthPoint);
            Debug.Log("Player two " + playerTwo.healthPoint);
        }
        //playerTwo.TakeDamageFromPlayer(playerOne);
        //playerOne.TakeDamageFromPlayer(playerTwo);
        Debug.Log("Final Player one " + playerOne.healthPoint);
        Debug.Log("Final Player two " + playerTwo.healthPoint);
        if(playerOne.healthPoint > playerTwo.healthPoint)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public bool PlayerVsMonster(Hero player, MonsterCard monster)
    {
        while (player.healthPoint >= 0.0f && monster.Health >= 0.0f)
        {
            player.TakeDamageFromMonster(monster);
            monster.TakeDamage(player);
            Debug.Log("Player one " + player.healthPoint);
            Debug.Log("Monster " + monster.Health);
        }
        //playerTwo.TakeDamageFromPlayer(playerOne);
        //playerOne.TakeDamageFromPlayer(playerTwo);
        Debug.Log("Final Player" + player.healthPoint);
        Debug.Log("Final monster" + monster.Health);

        if(player.healthPoint > monster.Health)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
