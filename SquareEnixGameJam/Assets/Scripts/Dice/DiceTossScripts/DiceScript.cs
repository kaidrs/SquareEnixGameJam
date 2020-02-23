using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScript : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

    public void RollDice()
    {
        diceVelocity = rb.velocity;
        DiceNumberTextScript.diceNumber = 0;
        float dirX = Random.Range(550, 700);
        float dirY = Random.Range(250, 700);
        float dirZ = Random.Range(550, 700);
        transform.position = new Vector3(0, 2, 0);
        transform.rotation = Quaternion.identity;
        rb.AddForce(transform.up * 750);
        rb.AddTorque(dirX, dirY, dirZ);
        FindObjectOfType<DiceCheckZoneScript>().Timer = 2f;
        FindObjectOfType<DiceCheckZoneScript>().RollComplete = false;
    }
}
