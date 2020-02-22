using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Card : MonoBehaviour
{
    private string cardName;
    private int cardNumber;

    protected Card(string name, int number)
    {
        this.cardName = name;
        this.cardNumber = number;
    }
}
