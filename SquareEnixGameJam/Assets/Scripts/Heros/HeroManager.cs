using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour
{
    [SerializeField] public Sprite warriorSprite;
    [SerializeField] public Sprite thiefSprite;
    [SerializeField] public Sprite paladinSprite;

    public List<Sprite> spriteList;

    [SerializeField] Text characterInfo;
    [SerializeField] GameObject panelInfo;
    private bool isPanelOn = false;
    private string textForUI;
    public int characterNumber;
    PlayerManager PMi;
    [SerializeField] GameObject panelWaitting;

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
        Hero warrior = new Warrior(100.0f, 10, 5, 5,"Warrior", 0);
        return warrior;
    }

    public Hero CreatePaladin()
    {
        Hero paladin = new Paladin(100.0f, 5, 10, 5,"Paladin", 2);
        //paladin.ClassText = "Paladin";
        return paladin;
    }

    public Hero CreateThief()
    {
        Hero thief = new Thief(100.0f,5,5,10,"Thief", 1);
        //thief.ClassText = "Thief";
        return thief;
    }

    public void PickClass()
    {
        panelWaitting.SetActive(true);
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
        PMi.ownerPlayer.hero = CreateWarrior();
        PMi.ownerPlayer.hero.playerName = PMi.ownerPlayer.displayName;
        GameScene();
    }

    public void PickPaladin()
    {
        PMi.ownerPlayer.hero = CreatePaladin();
        PMi.ownerPlayer.hero.playerName = PMi.ownerPlayer.displayName;
        GameScene();
    }

    public void PickThief()
    {
        PMi.ownerPlayer.hero = CreateThief();
        PMi.ownerPlayer.hero.playerName = PMi.ownerPlayer.displayName;
        GameScene();
    }

    public void WarriorChoice()
    {
        panelInfo.SetActive(true);
        textForUI = "--WARRIOR--\nStarting Stat\n\n Attack : 10 (Determine damage)\n\n Defence : 5 (% damage reduction) \n\n Luck : 5 (% dodge chance)";
        characterNumber = 1;
        isPanelOn = true;
    }

    public void PaladinChoice()
    {
        panelInfo.SetActive(true);
        textForUI = "--PALADIN--\nStarting Stat\n\n Attack : 5 (Determine damage)\n\n Defence : 10 (% damage reduction) \n\n Luck : 5 (% dodge chance)";
        characterNumber = 2;
        isPanelOn = true;
    }

    public void ThiefChoice()
    {
        panelInfo.SetActive(true);
        textForUI = "--THIEF--\nStarting Stat\n\n Attack : 5 (Determine damage)\n\n Defence : 5 (% damage reduction) \n\n Luck : 10 (% dodge chance)";
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
        PMi.ownerPlayer.punReady = true;

        PMi.BroadcastUpdate();
        isPanelOn = false;
        if (NetworkManager.Instance.AreAllReady())
        {
            NetworkManager.Instance.BroadcastLoadScene("Jeff"); 
        }
    }
}
