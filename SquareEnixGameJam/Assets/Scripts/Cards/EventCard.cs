using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/EventCard")]
public class EventCard : Card
{
    [Header("Event Properties")]
    [Tooltip("Event Description")]
    [TextArea(2,5)]
    [SerializeField] private string description = "Event Description";


    public void Event()
    {

    }

}
