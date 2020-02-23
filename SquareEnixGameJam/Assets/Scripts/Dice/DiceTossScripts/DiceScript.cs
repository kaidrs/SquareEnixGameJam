using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScript : MonoBehaviour
{

    public Vector3 diceVelocity;
    public bool isRolling;
    private Rigidbody rigidbody;
    public Button rollButton;

    public Vector3 ogPosition;
    private void Awake()
    {
        ogPosition = this.transform.position;
        rigidbody = GetComponent<Rigidbody>();
        ResetWaitPosition();
    }
    // Use this for initialization
    void Start()
    {
        
        DiceManager.Instance.diceText.text = "";
#if !UNITY_EDITOR
        rollButton.gameObject.SetActive(false);
#endif
    }

    private void Update()
    {
        diceVelocity = rigidbody.velocity;
        if (Input.GetKeyDown(KeyCode.K))
        {
            isRolling = false;
        }
    }

    public void RollDice()
    {
        if (!isRolling)
        {
            rigidbody.useGravity = true;
            Invoke("TextRoll", 0.1f);
            isRolling = true;
            //DiceNumberTextScript.diceNumber = 0;
            float dirX = Random.Range(550, 700);
            float dirY = Random.Range(550, 700);
            float dirZ = Random.Range(550, 700);
            transform.position = new Vector3(0, Random.Range(2, 3), 0);
            transform.rotation = new Quaternion(Random.Range(0, 181), Random.Range(0, 181), Random.Range(0, 181), transform.rotation.w);
            rigidbody.AddForce(transform.up * Random.Range(1000, 2001));
            rigidbody.AddTorque(dirX, dirY, dirZ);
        }
    }

    public void ResetWaitPosition()
    {
        rigidbody.useGravity = false;
        this.transform.position = ogPosition;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }
    private void TextRoll()
    {
        DiceManager.Instance.diceText.text = "Rolling...";
        Debug.Log("ResetText");
    }
}
