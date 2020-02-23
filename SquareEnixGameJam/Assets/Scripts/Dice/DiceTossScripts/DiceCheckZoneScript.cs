using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{
    Collider collider;

    void OnTriggerStay(Collider col)
    {
        collider = col;
    }

    private void Update()
    {
        if (DiceScript.diceVelocity == Vector3.zero)
        {
            if (collider.gameObject.tag == "DiceZone")
            {
                switch (collider.gameObject.name)
                {
                    case "Side1":
                        DiceManager.Instance.CurrentValue = 6;
                        break;
                    case "Side2":
                        DiceManager.Instance.CurrentValue = 5;
                        break;
                    case "Side3":
                        DiceManager.Instance.CurrentValue = 4;
                        break;
                    case "Side4":
                        DiceManager.Instance.CurrentValue = 3;
                        break;
                    case "Side5":
                        DiceManager.Instance.CurrentValue = 2;
                        break;
                    case "Side6":
                        DiceManager.Instance.CurrentValue = 1;
                        break;
                }
            }
        }
    }
}
