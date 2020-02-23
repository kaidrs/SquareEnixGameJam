using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Hero
{
    public Warrior(float healthPoint, int attackPoint, int defencePoint, int luck, string classText, Sprite heroSprite) : base(healthPoint, attackPoint, defencePoint, luck, classText, heroSprite)
    {
        this.healthPoint = healthPoint;
        this.attackPoint = attackPoint;
        this.defencePoint = defencePoint;
        this.luck = luck;
        this.classText = classText;
    }

}
