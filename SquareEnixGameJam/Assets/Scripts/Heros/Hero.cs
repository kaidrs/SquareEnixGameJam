using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private float healthPoint;
    private int attackPoint;
    private int defencePoint;
    private int luck;

    public float HealthPoint { get => healthPoint; set => healthPoint = value; }
    public int AttackPoint { get => attackPoint; set => attackPoint = value; }
    public int DefencePoint { get => defencePoint; set => defencePoint = value; }
    public int Luck { get => luck; set => luck = value; }

    public Hero(float healthPoint, int attackPoint, int defencePoint, int luck)
    {
        this.healthPoint = healthPoint;
        this.attackPoint = attackPoint;
        this.defencePoint = defencePoint;
        this.luck = luck;
    }

    public Hero()
    {

    }
}
