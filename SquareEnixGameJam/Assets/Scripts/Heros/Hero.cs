using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero
{
    private float healthPoint;
    private int attackPoint;
    private int defencePoint;
    private int luck;
    private SpellCard spell;
    private string classText;

    public float HealthPoint { get => healthPoint; set => healthPoint = value; }
    public int AttackPoint { get => attackPoint; set => attackPoint = value; }
    public int DefencePoint { get => defencePoint; set => defencePoint = value; }
    public int Luck { get => luck; set => luck = value; }
    public string ClassText { get => classText; set => classText = value; }

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
        int damageMultiplier = (100 / (100 + hero.defencePoint)); //Clamp to 0-100 percentage reduction
        this.healthPoint -= (hero.AttackPoint * damageMultiplier);
    }

    public void TakeDamageFromMonster(MonsterCard monster)
    {
        int damageMultiplier = (100 / (100 + this.defencePoint)); //Clamp to 0-100 percentage reduction
        this.healthPoint -= (monster.Attack * damageMultiplier);
    }
}
