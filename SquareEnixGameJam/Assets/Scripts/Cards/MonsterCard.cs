using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/MonsterCard")]
public class MonsterCard : Card
{
    [Header("Monster Properties")]
    [SerializeField] private float health;
    [SerializeField] private int defence;
    [SerializeField] private int attack;

    public int Attack { get => attack; set => attack = value; }
    public int Defence { get => defence; set => defence = value; }
    public float Health { get => health; set => health = value; }

    public void TakeDamage(Hero hero)
    {
        int damageMultiplier = (100 / (100 + defence)); //Clamp to 0-100 percentage reduction
        this.health -= (hero.AttackPoint * damageMultiplier);
    }
}
