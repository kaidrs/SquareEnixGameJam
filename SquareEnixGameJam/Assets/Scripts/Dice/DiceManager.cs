using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollDice()
    {
        int rand = Random.Range(1, 7);
        Debug.Log("Player moves " + rand + " steps forward");


    }
}
