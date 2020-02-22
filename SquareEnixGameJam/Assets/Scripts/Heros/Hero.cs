using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Hero
{
    public float healthPoint;
    public int attackPoint;
    public int defencePoint;
    public int luck;
    public string classText;
    public List<int> spellCards;

    //public float healthPoint { get => healthPoint; set => healthPoint = value; }
    //public int attackPoint { get => attackPoint; set => attackPoint = value; }
    //public int defencePoint { get => defencePoint; set => defencePoint = value; }
    //public int luck { get => luck; set => luck = value; }
    //public string classText { get => classText; set => classText = value; }
    //public List<int> spellCards { get => spellCards; set => spellCards = value; }

    public Hero(float healthPoint, int attackPoint, int defencePoint, int luck, string classText)
    {
        this.healthPoint = healthPoint;
        this.attackPoint = attackPoint;
        this.defencePoint = defencePoint;
        this.luck = luck;
        this.classText = classText;
    }

    public Hero()
    {

    }

    public void TakeDamageFromPlayer(Hero hero)
    {
        float damageMultiplier = (100 / (100 + (float)hero.defencePoint)); //Clamp to 0-100 percentage reduction
        this.healthPoint -= ((float)hero.attackPoint * damageMultiplier)/100.0f;
    
    }

    public void TakeDamageFromMonster(MonsterCard monster)
    {
        float damageMultiplier = (100 / (100 + (float)this.defencePoint)); //Clamp to 0-100 percentage reduction
        this.healthPoint -= ((float)monster.Attack * damageMultiplier);
    }
}
