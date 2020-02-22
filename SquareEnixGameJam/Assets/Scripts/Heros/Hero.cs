using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Hero
{
    private float healthPoint;
    private int attackPoint;
    private int defencePoint;
    private int luck;
    private List<int> spellCards;
    private string classText;

    public float HealthPoint { get => healthPoint; set => healthPoint = value; }
    public int AttackPoint { get => attackPoint; set => attackPoint = value; }
    public int DefencePoint { get => defencePoint; set => defencePoint = value; }
    public int Luck { get => luck; set => luck = value; }
    public string ClassText { get => classText; set => classText = value; }
    public List<int> SpellCards { get => spellCards; set => spellCards = value; }

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
