using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{
    [SerializeField] private DiceScript diceScript;
    
    private Collider collider;

    void OnTriggerStay(Collider col)
    {
        collider = col;
    }

    private void Update()
    {
        if (diceScript.diceVelocity == Vector3.zero)
        {
            if (collider != null && diceScript.isRolling && collider.gameObject.tag == "DiceZone")
            {
                switch (collider.gameObject.name)
                {
                    case "Side1":
                        DiceManager.Instance.SetDiceValue(6);
                        break;
                    case "Side2":
                        DiceManager.Instance.SetDiceValue(5);
                        break;
                    case "Side3":
                        DiceManager.Instance.SetDiceValue(4);
                        break;
                    case "Side4":
                        DiceManager.Instance.SetDiceValue(3);
                        break;
                    case "Side5":
                        DiceManager.Instance.SetDiceValue(2);
                        break;
                    case "Side6":
                        DiceManager.Instance.SetDiceValue(1);
                        break;
                }
            }
            else
            {
                if (diceScript.isRolling)
                {
                    diceScript.isRolling = false;
                    diceScript.RollDice(); 
                }
            }
        }
    }
}
