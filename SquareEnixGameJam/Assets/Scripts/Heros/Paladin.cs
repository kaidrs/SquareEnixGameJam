using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Hero
{
    public Paladin()
    {
        this.HealthPoint = 1.0f;
        this.AttackPoint = 2;
        this.DefencePoint = 5;
        this.Luck = 1;
        this.ClassText = "Paladin";
    }

    public Paladin(float healthPoint, int attackPoint, int defencePoint, int luck) : base(healthPoint, attackPoint, defencePoint, luck)
    {
        healthPoint = 1.0f;
        attackPoint = 2;
        defencePoint = 5;
        luck = 1;
    }

    
}
