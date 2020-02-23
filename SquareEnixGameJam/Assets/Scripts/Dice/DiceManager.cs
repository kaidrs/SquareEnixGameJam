using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
{
    public Text diceText;

    // Value 1 - 6
    public int value;

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

    void Update()
    {
        diceText.text = "VALUE: " + value;
    }


    public int RollDiceNaive()
    {
        int rand = Random.Range(1, 7);
        return rand;
    }
    
}
