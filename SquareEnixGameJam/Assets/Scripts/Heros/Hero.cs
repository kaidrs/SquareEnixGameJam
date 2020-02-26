using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

[Serializable]
public class Hero
{
    public int heroSprite;
    public float healthPoint;
    public int attackPoint;
    public int defencePoint;
    public int luck;
    public string classText;
    public List<int> spellCards;
    public string playerName;

    //public float healthPoint { get => healthPoint; set => healthPoint = value; }
    //public int attackPoint { get => attackPoint; set => attackPoint = value; }
    //public int defencePoint { get => defencePoint; set => defencePoint = value; }
    //public int luck { get => luck; set => luck = value; }
    //public string classText { get => classText; set => classText = value; }
    //public List<int> spellCards { get => spellCards; set => spellCards = value; }

    public Hero(float healthPoint, int attackPoint, int defencePoint, int luck, string classText, int heroSprite)
    {
        this.healthPoint = healthPoint;
        this.attackPoint = attackPoint;
        this.defencePoint = defencePoint;
        this.luck = luck;
        this.classText = classText;
        this.heroSprite = heroSprite;
    }
    
    public void TakeDamageFromPlayer(Hero hero)
    {
        int dodgeChange = Random.Range(0, 100);
        float damageMultiplier = (100.0f / (100.0f + (float)hero.defencePoint)); //Clamp to 0-100 percentage reduction
        if (dodgeChange <= this.luck)
        {
            this.healthPoint -= 0;
            Debug.Log("MISS NOOB");
        }
        else
        {
            this.healthPoint -= ((float)hero.attackPoint * damageMultiplier);
        }
    }

    public void TakeDamageFromMonster(MonsterCard monster)
    {
        int dodgeChange = Random.Range(0, 100);
        float damageMultiplier = (100 / (100 + (float)this.defencePoint)); //Clamp to 0-100 percentage reduction
        if (dodgeChange <= this.luck)
        {
            this.healthPoint -= 0;
        }
        this.healthPoint -= ((float)monster.Attack * damageMultiplier);
    }

    public override string ToString()
    {
        return $"Hero Stats:: Health: {healthPoint}, Attack: {attackPoint}, Defense: {defencePoint}, Luck: {luck}, ClassText: {classText}";
    }
}
