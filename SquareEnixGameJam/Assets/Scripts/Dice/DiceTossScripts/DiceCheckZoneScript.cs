using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour {

	Vector3 diceVelocity;

    // Update is called once per frame
    void FixedUpdate () {
		diceVelocity = DiceScript.diceVelocity;
	}

    void OnTriggerStay(Collider col)
	{
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
        {
            if (col.gameObject.tag == "DiceZone")
            {
                Debug.Log("col.gameObject.name: " + col.gameObject.name);
                switch (col.gameObject.name)
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
                Debug.Log("Upper side is now: " + DiceManager.Instance.CurrentValue);
            }


        }

    }
}
