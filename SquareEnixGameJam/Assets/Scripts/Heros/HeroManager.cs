using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour
{
    public static List<Hero> playerChoice = new List<Hero>();
    [SerializeField] Text characterInfo;
    [SerializeField] GameObject panelInfo;
    private bool isPanelOn = false;
    private string textForUI;
    public int characterNumber;

    #region Singleton
    private static HeroManager _instance = null;

    public static HeroManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<HeroManager>();
            }
            return _instance;
        }
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPanelOn)
        {
            characterInfo.text = textForUI;
        }
    }

    public Hero CreateWarrior()
    {
        Hero warrior = ScriptableObject.CreateInstance<Warrior>();
        warrior.HealthPoint = 1.0f;
        warrior.AttackPoint = 10;
        warrior.DefencePoint = 5;
        warrior.Luck = 1;
        warrior.ClassText = "Warrior";
        return warrior;
    }

    public Hero CreatePaladin()
    {
        Hero paladin = ScriptableObject.CreateInstance<Paladin>();
        paladin.HealthPoint = 1.0f;
        paladin.AttackPoint = 10;
        paladin.DefencePoint = 5;
        paladin.Luck = 1;
        paladin.ClassText = "Paladin";
        return paladin;
    }

    public Hero CreateThief()
    {
        Hero thief = ScriptableObject.CreateInstance<Thief>();
        thief.HealthPoint = 1.0f;
        thief.AttackPoint = 5;
        thief.DefencePoint = 5;
        thief.Luck = 10;
        thief.ClassText = "Thief";
        return thief;
    }

    public void PickClass()
    {
        if(characterNumber == 1)
        {
            PickWarrior();
        }
        if(characterNumber == 2)
        {
            PickPaladin();
        }
        if(characterNumber == 3)
        {
            PickThief();
        }
    }


    public void PickWarrior()
    {
        playerChoice.Add(CreateWarrior());
        GameScene();
    }

    public void PickPaladin()
    {
        playerChoice.Add(CreatePaladin());
        GameScene();
    }

    public void PickThief()
    {
        playerChoice.Add(CreateThief());
        GameScene();
    }

    public void WarriorChoice()
    {
        panelInfo.SetActive(true);
        textForUI = "Starting Stat\n\n Attack : 10 (Determine damage)\n\n Defence : 5 (% damage reduction) \n\n Luck : 5 (% dodge chance)";
        characterNumber = 1;
        isPanelOn = true;
    }

    public void PaladinChoice()
    {
        panelInfo.SetActive(true);
        textForUI = "Starting Stat\n\n Attack : 5 (Determine damage)\n\n Defence : 10 (% damage reduction) \n\n Luck : 5 (% dodge chance)";
        characterNumber = 2;
        isPanelOn = true;
    }

    public void ThiefChoice()
    {
        panelInfo.SetActive(true);
        textForUI = "Starting Stat\n\n Attack : 5 (Determine damage)\n\n Defence : 5 (% damage reduction) \n\n Luck : 10 (% dodge chance)";
        characterNumber = 3;
        isPanelOn = true;
    }

    public void BackToSelection()
    {
        isPanelOn = false;
        panelInfo.SetActive(false);
    }


    public void GameScene()
    {
        //jeff need help
        isPanelOn = false;
        SceneManager.LoadScene("Jeff");
    }
}
