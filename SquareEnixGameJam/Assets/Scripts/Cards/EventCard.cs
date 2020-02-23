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

    public enum Category
    {
        None, PlayerDisplacement, InventoryChange
    }

    public Category eventType;

    public void Event()
    {
        switch(eventType)
        {
            case Category.PlayerDisplacement:
                //get currentplayer, set tile position
                break;
            case Category.InventoryChange:
                break;
        }
    }

}
