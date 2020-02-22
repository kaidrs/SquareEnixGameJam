using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private Hero hero; //change later

   // [SerializeField] GameObject heroSprite;
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
        hero = HeroManager.playerChoice[0];
        InitInventoryUI();
        
    }


    public void InitInventoryUI()
    {
        heroNameText.text = hero.name;
        heroClassText.text = hero.ClassText;
        heroAttackText.text = hero.AttackPoint.ToString();
        heroDefenseText.text = hero.DefencePoint.ToString();
        heroLuckText.text = hero.Luck.ToString();
        //spellcard name?

    }


    // Update is called once per frame
    void Update()
    {

    }
}