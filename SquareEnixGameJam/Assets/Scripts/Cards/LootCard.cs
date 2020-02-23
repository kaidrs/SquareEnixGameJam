using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/LootCard")]
public class LootCard : Card
{
	[Header("Loot Properties")]
	[SerializeField] private int attackStat;
	[SerializeField] private int defenceStat;
	[SerializeField] private int luckStat;

	public void AddStatToPlayer(Hero hero)
	{
		hero.attackPoint += this.attackStat;
		hero.defencePoint += this.defenceStat;
		hero.luck += this.luckStat;
	}
}
