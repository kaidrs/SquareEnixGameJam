using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCard : Card
{
    float health = 1;
    int damage;
    int defense;

	public MonsterCard(string name, int number, int damage, int defense):base(name, number)
	{
        this.damage = damage;
        this.defense = defense;
	}

    public void TakeDamage(Hero hero)
    {
        float damageMultiplier = (100 / (100 + defense)); //Clamp to 0-100 percentage reduction
        this.health -= (hero.AttackPoint * damageMultiplier);
    }

}
