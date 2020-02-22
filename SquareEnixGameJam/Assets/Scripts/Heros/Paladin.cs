using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Hero
{
    public Paladin()
    {
        this.HealthPoint = 1.0f;
        this.AttackPoint = 5;
        this.DefencePoint = 10;
        this.Luck = 5;
        this.ClassText = "Paladin";
    }

    public Paladin(float healthPoint, int attackPoint, int defencePoint, int luck, string classText) : base(healthPoint, attackPoint, defencePoint, luck, classText)
    {
        healthPoint = 1.0f;
        attackPoint = 5;
        defencePoint = 10;
        luck = 5;
        classText = "Paladin";
    }
}
