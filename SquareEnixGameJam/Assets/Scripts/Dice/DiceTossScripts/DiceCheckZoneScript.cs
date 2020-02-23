using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{

    Vector3 diceVelocity;
    float timer = 2f;
    bool rollComplete;

    public float Timer { get => timer; set => timer = value; }
    public bool RollComplete { get => rollComplete; set => rollComplete = value; }

    // Update is called once per frame
    void FixedUpdate()
    {
        diceVelocity = DiceScript.diceVelocity;
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "DiceZone")
        {
            Timer = 2f;
            Debug.Log("timer reset");
        }

    }

    void OnTriggerStay(Collider col)
    {
       // Debug.LogError("timer is : " + timer);

        if (timer >= 0)
        {
            Timer -= Time.deltaTime;
            //Debug.Log(Timer);
        }

        else if (Timer <= 0 && !RollComplete)
        {
            RollComplete = true;
           // Timer = 2f;
            if (col.gameObject.tag == "DiceZone")
            {
                Debug.LogError("col.gameObject.name: " + col.gameObject.name);
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
                Debug.Log(timer); 
            }



        }


    }
}
