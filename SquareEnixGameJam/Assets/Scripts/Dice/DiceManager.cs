using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
{
    public Text diceText;
    public DiceScript diceScript;
    // Value 1 - 6
    public int value;
    public bool isSet = false;
    //public GameObject Dice;

    #region Singleton
    private static DiceManager _instance = null;

    public static DiceManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DiceManager>();
            }
            return _instance;
        }
    }
    #endregion

    void Awake()
    {
        #region Dont Destroy On Load
        var objects = FindObjectsOfType(this.GetType());
        if (objects.Length > 1)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        #endregion
    }

    public int RollDiceNaive()
    {
        int rand = Random.Range(1, 7);
        return rand;
    }

    public void SetDiceValue(int value)
    {
        isSet = true;
        Debug.Log("SetDiceValue");
        this.value = value;
        diceText.text = "VALUE: " + value;
        Invoke("Advance", 3.0f);
    }

    public void Advance()
    {
        Debug.Log("Advance");
        UIManager.Instance.ShowInventory();
        diceScript.ResetWaitPosition();
        Debug.Log($"Send value:{value} to tile manager");
        TileManager.Instance.SetPlayerTilePosition(value);

    }
}
