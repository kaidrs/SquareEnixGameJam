using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScript : MonoBehaviour {

	public static Vector3 diceVelocity;

	private Rigidbody rigidbody;
    private bool isRolling;

	// Use this for initialization
	void Start () 
    {
		rigidbody = GetComponent<Rigidbody> ();
	}

    private void Update()
    {
        diceVelocity = rigidbody.velocity;

        //DEBUG
        if (Input.GetKeyDown(KeyCode.K)) { isRolling = false; }
    }

    public void RollDice()
    {
        if (!isRolling)
        {
            isRolling = true;
            DiceNumberTextScript.diceNumber = 0;
            float dirX = Random.Range(550, 700);
            float dirY = Random.Range(550, 700);
            float dirZ = Random.Range(550, 700);
            transform.position = new Vector3(0, Random.Range(2, 3), 0);
            transform.rotation = new Quaternion(Random.Range(0, 181), Random.Range(0, 181), Random.Range(0, 181), transform.rotation.w);
            rigidbody.AddForce(transform.up * Random.Range(1000, 2001));
            rigidbody.AddTorque(dirX, dirY, dirZ); 
        }
    }
}
