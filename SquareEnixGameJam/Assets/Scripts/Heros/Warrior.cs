using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Hero
{

    public Warrior(float healthPoint, int attackPoint, int defencePoint, int luck) : base(healthPoint, attackPoint, defencePoint, luck)
    {
        healthPoint = 1.0f;
        attackPoint = 5;
        defencePoint = 2;
        luck = 1;
    }
}
