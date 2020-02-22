using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestClass : MonoBehaviour
{
    [SerializeField] Text classes;
    string playerClass = "";

    // Start is called before the first frame update
    void Start()
    {
        playerClass = HeroManager.playerChoice[0].Luck.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        classes.text = playerClass;
    }
}
