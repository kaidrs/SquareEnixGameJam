using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsCurrentTurn : MonoBehaviour
{
    [Header("Inventory Canvas")]
    public Color yourTurn = Color.green;
    public Color waitTurn = Color.red;
    public Image currentTurnPanel;

    // Update is called once per frame
    void Update()
    {
        bool myTurn = PlayerManager.Instance.IsCurrent;
        if (myTurn)
        {
            currentTurnPanel.color = yourTurn;
            Debug.Log("Your Turn");
        }
        else
        {
            currentTurnPanel.color = waitTurn;
            Debug.Log("Wait Turn");
        }
    }
}
