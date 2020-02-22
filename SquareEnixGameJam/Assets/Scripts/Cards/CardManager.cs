using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardManager : MonoBehaviour
{

    #region Singleton

    private static CardManager instance;
  
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

    [SerializeField] Card[] CardColletion;

    Card CallCard(int cardNumber)
    {
        for (int i = 0; i < CardColletion.Length; i++)
        {
            if (CardColletion[i].CardNumber == cardNumber)
            {
                return CardColletion[i];
            }
        }
        return null;
    }

}
