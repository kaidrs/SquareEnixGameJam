using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private Hero hero; //change later

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



    // Start is called before the first frame update
    void Start()
    {

        if(PlayerManager.Instance != null)
        {
            hero = PlayerManager.Instance.ownerPlayer.hero;
            InitInventoryUI();
        }
     
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