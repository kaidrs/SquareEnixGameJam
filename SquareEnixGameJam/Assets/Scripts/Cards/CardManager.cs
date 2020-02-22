using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardManager : MonoBehaviour
{

    #region Singleton

    private static CardManager instance = null;
  
    public static CardManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CardManager>();
            }

            return instance;
        }
    }

    #endregion

    List<Card[]> cardColletion;

    [SerializeField] private LootCard[] lootCardColletion;
    [SerializeField] private MonsterCard[] monsterCardColletion;
    [SerializeField] private SpellCard[] spellCardColletion;
    [SerializeField] private EventCard[] eventCardColletion;


    private void Start()
    {
        cardColletion = new List<Card[]>();
        cardColletion.Add(lootCardColletion);
        cardColletion.Add(monsterCardColletion);
        cardColletion.Add(spellCardColletion);
        cardColletion.Add(eventCardColletion);
    }

    public LootCard CallLootCard(int cardNumber)
    {
        for (int i = 0; i < lootCardColletion.Length; i++)
        {
            if (lootCardColletion[i].CardNumber == cardNumber)
            {
                return lootCardColletion[i];
            }
        }
        return null;
    }

    public MonsterCard CallMonsterCard(int cardNumber)
    {
        for (int i = 0; i < monsterCardColletion.Length; i++)
        {
            if (monsterCardColletion[i].CardNumber == cardNumber)
            {
                return monsterCardColletion[i];
            }
        }

        return null;
    }

    public SpellCard CallSpellCard(int cardNumber)
    {
        for (int i = 0; i < spellCardColletion.Length; i++)
        {
            if (spellCardColletion[i].CardNumber == cardNumber)
            {
                return spellCardColletion[i];
            }
        }

        return null;
    }

    public EventCard CallEventCard(int cardNumber)
    {
        for (int i = 0; i < eventCardColletion.Length; i++)
        {
            if (eventCardColletion[i].CardNumber == cardNumber)
            {
                return eventCardColletion[i];
            }
        }

        return null;
    }

    public Card CallCard(int cardNumber)
    {
        foreach (var collection in cardColletion)
        {
            foreach (var card in collection)
            {
                if (card.CardNumber == cardNumber)
                {
                    return card;
                }
            }
        }
        return null;
    }

}
