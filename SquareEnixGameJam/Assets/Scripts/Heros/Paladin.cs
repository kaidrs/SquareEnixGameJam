using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Hero
{
    public Paladin(float healthPoint, int attackPoint, int defencePoint, int luck, string classText, Sprite heroSprite) : base(healthPoint, attackPoint, defencePoint, luck, classText, heroSprite)
    {
        healthPoint = 1.0f;
        attackPoint = 5;
        defencePoint = 10;
        luck = 5;
        classText = "Paladin";
    }
}
