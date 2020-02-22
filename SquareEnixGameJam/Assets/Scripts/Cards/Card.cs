using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
{
    [Header("Card Properties")]
    [SerializeField] private string cardName;
    [SerializeField] private int cardNumber;

    [SerializeField] private Sprite cardSprite;
}
