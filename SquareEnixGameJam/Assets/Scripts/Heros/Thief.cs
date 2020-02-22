using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Hero
{

    public Thief(float healthPoint, int attackPoint, int defencePoint, int luck) : base(healthPoint, attackPoint, defencePoint, luck)
    {
        healthPoint = 1.0f;
        attackPoint = 2;
        DefencePoint = 2;
        luck = 5;
    }
}
