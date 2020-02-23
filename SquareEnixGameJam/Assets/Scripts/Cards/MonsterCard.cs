using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MonsterCard", menuName = "Cards/MonsterCard")]
public class MonsterCard : Card
{
    [Header("Monster Properties")]
    [SerializeField] private float health;
    [SerializeField] private int defence;
    [SerializeField] private int attack;
    public bool bossCard = false;
    public ZoneType zone;
    public int Attack { get => attack; set => attack = value; }
    public int Defence { get => defence; set => defence = value; }
    public float Health { get => health; set => health = value; }

    public MonsterCard(int attack, int defence, float health)
    {
        this.attack = attack;
        this.defence = defence;
        this.health = health;
    }

    public void TakeDamage(Hero hero)
    {
        float damageMultiplier = (100.0f / (100.0f + (float)defence)); //Clamp to 0-100 percentage reduction
        this.health -= ((float)hero.attackPoint * damageMultiplier);
    }
}
