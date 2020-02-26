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

    private void Awake()
    {
        PMi = PlayerManager.Instance;
    }

    public IEnumerator PlayerVsPlayer(Hero playerOne, Hero playerTwo)
    {
        var og1HP = playerOne.healthPoint;
        var og2HP = playerTwo.healthPoint;
        if (PMi.ownerPlayer.hero.spellCards != null)
        {
            //Do you wanna use spell panel
        }

        while (playerOne.healthPoint >= 0.0f && playerTwo.healthPoint >= 0.0f)
        {
            playerTwo.TakeDamageFromPlayer(playerOne);
            yield return new WaitForSeconds(0.1f);
            UIManager.Instance.P2HpSlider.value = playerTwo.healthPoint;
            Debug.Log("Player two " + playerTwo.healthPoint);
            playerOne.TakeDamageFromPlayer(playerTwo);
            yield return new WaitForSeconds(0.1f);
            UIManager.Instance.P1HpSlider.value = playerOne.healthPoint;
            Debug.Log("Player one " + playerOne.healthPoint);
        }
        //playerTwo.TakeDamageFromPlayer(playerOne);
        //playerOne.TakeDamageFromPlayer(playerTwo);
        //Debug.Log("Final Player one " + playerOne.healthPoint);
        //Debug.Log("Final Player two " + playerTwo.healthPoint);
        bool result = playerOne.healthPoint > playerTwo.healthPoint;
        playerOne.healthPoint = og1HP;
        playerTwo.healthPoint = og2HP;
        if (result)
        {
            LootCard rewardCardLooted = CardManager.Instance.GetRandomLoot();
            UIManager.Instance.PromptReward(rewardCardLooted);
        }
        Debug.Log(result);
        UIManager.Instance.HidePrompts();
        UIManager.Instance.ShowInventory();
        NetworkManager.Instance.BroadcastUpdateTurn(); // Ends the turn
        // push player back;
    }


    public IEnumerator PlayerVsMonster(Hero player, MonsterCard monster)
    {
        var ogHP = player.healthPoint;
        var monsterCardCopy = monster.GetCopy();
        while (player.healthPoint >= 0.0f && monsterCardCopy.Health >= 0.0f)
        {

            monsterCardCopy.TakeDamage(player);
            yield return new WaitForSeconds(0.1f);
            Debug.Log("Monster " + monsterCardCopy.Health);
            player.TakeDamageFromMonster(monsterCardCopy);
            yield return new WaitForSeconds(0.1f);
            UIManager.Instance.P1HpSlider.value = player.healthPoint;
            Debug.Log("Player one " + player.healthPoint);
            UIManager.Instance.P2HpSlider.value = monsterCardCopy.Health;
        }

        bool result = player.healthPoint > monsterCardCopy.Health;
        UIManager.Instance.HidePrompts();
        player.healthPoint = ogHP;
        if (result)
        {
            LootCard rewardCardLooted = CardManager.Instance.GetRandomLoot();
            UIManager.Instance.PromptReward(rewardCardLooted);
        }
        UIManager.Instance.ShowInventory();
        NetworkManager.Instance.BroadcastUpdateTurn(); // Ends the turn
    }
}
