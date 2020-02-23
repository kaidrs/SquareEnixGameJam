using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Hero myHero;

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

    [SerializeField] public List<GameObject> spells;
    private int availableSpellSlots;

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
        myHero = PlayerManager.Instance.ownerPlayer.hero;
        availableSpellSlots = spells.Count;
        InitInventoryUI();
    }


    public void InitInventoryUI()
    {
        //heroNameText.text = hero.name;
        
        heroClassText.text = myHero.classText;
        UpdateSprite(myHero.classText);
        heroAttackText.text = myHero.attackPoint.ToString();
        heroDefenseText.text = myHero.defencePoint.ToString();
        heroLuckText.text = myHero.luck.ToString();
        //spellcard name?

    }

    public void PopulateSpell(SpellCard card)
    {
        if (availableSpellSlots > 0)
        {
            GameObject nextAvailableSlot = spells[spells.Count - availableSpellSlots];
            nextAvailableSlot.GetComponent<Image>().sprite = card.CardSprite;
            availableSpellSlots--;
        } else
        {
            Debug.Log("PopulateSpell::Spell slot is full!");
        }

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
}