using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCard : Card
{
	private int attackStat;
	private int defenceStat;

	public LootCard(string name, int number, int attack, int defence):base(name, number)
	{
		this.attackStat = attack;
		this.defenceStat = defence;
	}

	public void AddStatToPlayer(/*Hero hero*/)
	{
		//hero.attack += this.attackStat;
		//hero.defence += this.defenceStat;
	}
}
