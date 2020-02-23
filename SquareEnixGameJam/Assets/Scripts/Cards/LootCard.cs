using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/LootCard")]
public class LootCard : Card
{
	[Header("Loot Properties")]
	[SerializeField] public int attackStat;
	[SerializeField] public int defenceStat;
	[SerializeField] public int luckStat;

	public void AddStatToPlayer(Hero hero)
	{
		hero.attackPoint += attackStat;
		hero.defencePoint += defenceStat;
		hero.luck += luckStat;
	}
}
