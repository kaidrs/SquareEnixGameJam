using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MonsterCard", menuName = "Cards/MonsterCard")]
public class MonsterCard : Card
{
    [Header("Monster Properties")]
    private float health = 100;
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
        this.health = 100;
    }

    public void TakeDamage(Hero hero)
    {
        float damageMultiplier = (100.0f / (100.0f + (float)defence)); //Clamp to 0-100 percentage reduction
        this.health -= ((float)hero.attackPoint * damageMultiplier);
    }
    public MonsterCard GetCopy()
    {
        int multiplier = (int)PlayerManager.Instance.ownerPlayer.zone + 1;
        var attack = this.attack * multiplier;
        var defence = this.defence * multiplier;
        var health = this.health * multiplier;
        MonsterCard newCard = new MonsterCard(attack, defence, health);
        newCard.CardName = this.CardName;
        newCard.CardNumber = this.CardNumber;
        Debug.Log(newCard);
        return newCard;
    }
    public override string ToString()
    {
        int multiplier = (int)PlayerManager.Instance.ownerPlayer.zone + 1;
        return $"Stat:\n Health:{health * multiplier}\nAttack:{attack * multiplier}\nDefence:{Defence * multiplier}\n";
    }
}
