using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/LootCard")]
public class LootCard : Card
{
	[Header("Loot Properties")]
	[SerializeField] private int attackStat;
	[SerializeField] private int defenceStat;

	public void AddStatToPlayer(Hero hero)
	{
		hero.AttackPoint += this.attackStat;
		hero.DefencePoint += this.defenceStat;
	}
}
