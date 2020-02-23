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
        //Hero thief = new Thief(100.0f, 5, 5, 25, "Thief", HeroManager.Instance.thiefSprite);
        //Hero warrior = new Warrior(100.0f, 25, 5, 5, "Warrior", HeroManager.Instance.warriorSprite);
        //MonsterCard monster = ScriptableObject.CreateInstance<MonsterCard>();
        //monster.Attack = 5;
        //monster.Defence = 2;
        //monster.Health = 100.0f;


        //UIManager.Instance.inBattle = true;
        //UIManager.Instance.PromptBattle(thief, warrior);
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

            UIManager.Instance.P1HpSlider.value = playerTwo.healthPoint;
            UIManager.Instance.P2HpSlider.value = playerOne.healthPoint;
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
        var monsterCardCopy = monster.GetCopy();
        while (player.healthPoint >= 0.0f && monsterCardCopy.Health >= 0.0f)
        {
            player.TakeDamageFromMonster(monsterCardCopy);
            monsterCardCopy.TakeDamage(player);
            Debug.Log("Player one " + player.healthPoint);
            Debug.Log("Monster " + monsterCardCopy.Health);
        }
        //playerTwo.TakeDamageFromPlayer(playerOne);
        //playerOne.TakeDamageFromPlayer(playerTwo);
        Debug.Log("Final Player" + player.healthPoint);
        Debug.Log("Final monster" + monsterCardCopy.Health);

        if(player.healthPoint > monsterCardCopy.Health)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
