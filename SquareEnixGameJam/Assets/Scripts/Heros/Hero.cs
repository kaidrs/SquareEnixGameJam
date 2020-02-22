using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : ScriptableObject
{
    private float healthPoint;
    private int attackPoint;
    private int defencePoint;
    private int luck;

    public float HealthPoint { get => healthPoint; set => healthPoint = value; }
    public int AttackPoint { get => attackPoint; set => attackPoint = value; }
    public int DefencePoint { get => defencePoint; set => defencePoint = value; }
    public int Luck { get => luck; set => luck = value; }

    public Hero(float healthPoint, int attackPoint, int defencePoint, int luck)
    {
        this.healthPoint = healthPoint;
        this.attackPoint = attackPoint;
        this.defencePoint = defencePoint;
        this.luck = luck;
    }

    public Hero()
    {

    }

    public void TakeDamageFromPlayer(Hero hero)
    {
        int damageMultiplier = (100 / (100 + hero.defencePoint)); //Clamp to 0-100 percentage reduction
        this.healthPoint -= (hero.AttackPoint * damageMultiplier);
    }

    public void TakeDamageFromMonster()
    {
       
    }
}
