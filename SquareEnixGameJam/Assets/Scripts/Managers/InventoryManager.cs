using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject heroSprite;
    [SerializeField] Text heroNameText;
    [SerializeField] Text heroClassText;
    [SerializeField] Text heroAttackText;
    [SerializeField] Text heroDefenseText;
    [SerializeField] Text heroLuckText;
    [SerializeField] Text heroSpellText;

    [SerializeField] Image heroWeaponImage;
    [SerializeField] Image heroDefenseImage;
    [SerializeField] Image heroLuckImage;
    [SerializeField] Image heroSpellImage;

    //Get Hero photon shananagin later
    Hero hero;


    // Start is called before the first frame update
    void Start()
    {
       // hero = GetComponent<Hero>();


    }


    public void InitInventoryUI()
    {
        heroNameText.text = hero.name;
        heroClassText.text = hero.ClassText;
        heroAttackText.text = hero.AttackPoint.ToString();
        heroDefenseText.text = hero.DefencePoint.ToString();
        heroLuckText.text = hero.Luck.ToString();
        //heroSpellText.text = SpellCard.name

    }


    // Update is called once per frame
    void Update()
    {

    }
}