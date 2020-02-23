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
        if (DiceScript.diceVelocity == Vector3.zero)
        {
            if (collider != null && collider.gameObject.tag == "DiceZone")
            {
                switch (collider.gameObject.name)
                {
                    case "Side1":
                        DiceManager.Instance.value = 6;
                        break;
                    case "Side2":
                        DiceManager.Instance.value = 5;
                        break;
                    case "Side3":
                        DiceManager.Instance.value = 4;
                        break;
                    case "Side4":
                        DiceManager.Instance.value = 3;
                        break;
                    case "Side5":
                        DiceManager.Instance.value = 2;
                        break;
                    case "Side6":
                        DiceManager.Instance.value = 1;
                        break;
                }
            }
            else
            {
                diceScript.RollDice();
            }
        }
    }
}
