using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Hero hero; //change later

    //public Hero CurrentHero { get => hero; set => CurrentHero = value; }

    // [SerializeField] Animator spriteAnimator;
    // [SerializeField] Image heroSprite;
    //[SerializeField] GameObject heroObject;
    [SerializeField] GameObject warriorObject;
    [SerializeField] GameObject thiefObject;
    [SerializeField] GameObject paladinObject;
    [SerializeField] Text heroNameText;
    [SerializeField] Text heroClassText;
    [SerializeField] Text heroAttackText;
    [SerializeField] Text heroDefenseText;
    [SerializeField] Text heroLuckText;
    // [SerializeField] Text heroSpellText;

    //  [SerializeField] Image heroWeaponImage;
    // [SerializeField] Image heroDefenseImage;
    // [SerializeField] Image heroLuckImage;
    //[SerializeField] Image heroSpellImage;

    #region Singleton
    private static InventoryManager _instance = null;

    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InventoryManager>();
            }
            return _instance;
        }
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        hero = HeroManager.playerChoice[0];
        //hero = new Hero(1, 1, 1, 1);
        InitInventoryUI();
        
    }


    public void InitInventoryUI()
    {
        //heroNameText.text = hero.name;
        
        heroClassText.text = hero.classText;
        UpdateSprite(hero.classText);
        heroAttackText.text = hero.attackPoint.ToString();
        heroDefenseText.text = hero.defencePoint.ToString();
        heroLuckText.text = hero.luck.ToString();
        //spellcard name?

    }


    private void UpdateSprite(string classText)
    {
        if (classText == "Thief")
        {
            thiefObject.SetActive(true);
            Debug.Log("switch to thief");
        }
        else if (classText == "Warrior")
        {
            warriorObject.SetActive(true);
            Debug.Log("switch to " + classText);
        }
        else
        {
            paladinObject.SetActive(true);
            Debug.Log("switch to paladin");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}