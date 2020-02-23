using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Hero
{
    public Warrior(float healthPoint, int attackPoint, int defencePoint, int luck, string classText, Sprite heroSprite) : base(healthPoint, attackPoint, defencePoint, luck, classText, heroSprite)
    {
        healthPoint = 100.0f;
        attackPoint = 10;
        defencePoint = 5;
        luck = 5;
        classText = "Warrior";
    }
}
