using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Hero
{

    public Warrior(float healthPoint = 100.0f, int attackPoint = 10, int defencePoint = 5, int luck = 5, string classText = "Warrior") : base(healthPoint, attackPoint, defencePoint, luck, classText)
    {
        this.healthPoint = healthPoint;
        this.attackPoint = attackPoint;
        this.defencePoint = defencePoint;
        this.luck = luck;
        this.classText = classText;
    }

}
