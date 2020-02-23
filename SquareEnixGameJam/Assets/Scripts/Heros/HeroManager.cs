using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour
{
    Hero ok;
    // static List<Hero> playerChoice = new List<Hero>();
    [SerializeField] Text characterInfo;
    [SerializeField] GameObject panelInfo;
    private bool isPanelOn = false;
    private string textForUI;
    public int characterNumber;
    PlayerManager PMi;

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
    private void Awake()
    {
        PMi = PlayerManager.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
       // PlayerManager.Instance.ownerPlayer.hero = new Hero();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPanelOn)
        {
            characterInfo.text = textForUI;
        }
    }

    public static Hero CreateWarrior()
    {
        Hero warrior = new Warrior(100.0f, 10, 5, 5,"Warrior");
        return warrior;
    }

    public Hero CreatePaladin()
    {
        Hero paladin = new Paladin(100.0f, 5, 10, 5,"Paladin");
        //paladin.ClassText = "Paladin";
        return paladin;
    }

    public Hero CreateThief()
    {
        Hero thief = new Thief(100.0f,5,5,10,"Thief");
        //thief.ClassText = "Thief";
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
        PlayerManager.Instance.ownerPlayer.hero = CreateWarrior();
        PMi.BroadcastUpdate();
        GameScene();
    }

    public void PickPaladin()
    {
        PlayerManager.Instance.ownerPlayer.hero = CreatePaladin();
        PMi.BroadcastUpdate();
        GameScene();
    }

    public void PickThief()
    {

        PlayerManager.Instance.ownerPlayer.hero = CreateThief();
        PMi.BroadcastUpdate();
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
