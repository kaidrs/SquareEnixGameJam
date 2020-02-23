using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Hero
{
    public Paladin()
    {
        this.healthPoint = 100.0f;
        this.attackPoint = 5;
        this.defencePoint = 10;
        this.luck = 5;
        this.classText = "Paladin";
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
