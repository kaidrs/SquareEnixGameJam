using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Hero
{

    public Paladin(float healthPoint, int attackPoint, int defencePoint, int luck) : base(healthPoint, attackPoint, defencePoint, luck)
    {
        healthPoint = 1.0f;
        attackPoint = 2;
        defencePoint = 5;
        luck = 1;
    }

    
}
