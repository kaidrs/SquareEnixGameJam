using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
{
    //Fields
    [Header("Card Properties")]
    [SerializeField] private string cardName;
    [SerializeField] private int cardNumber;

    [SerializeField] private Sprite cardSprite;

    //Properties
    public string CardName { get => cardName; set => cardName = value; }
    public int CardNumber { get => cardNumber; set => cardNumber = value; }
    public Sprite CardSprite { get => cardSprite; set => cardSprite = value; }


}
