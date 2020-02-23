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

	public void AddStatToPlayer()
	{
		var hero = PlayerManager.Instance.ownerPlayer.hero;
		int multiplier = (int)PlayerManager.Instance.ownerPlayer.zone + 1;
		hero.attackPoint += this.attackStat * multiplier;
		hero.defencePoint += this.defenceStat * multiplier;
		hero.luck += this.luckStat * multiplier;
		PlayerManager.Instance.BroadcastUpdate();
	}
	public override string ToString()
	{
		int multiplier = (int)PlayerManager.Instance.ownerPlayer.zone + 1;
		return $"Stat:\n Attack:{attackStat * multiplier}\nDefence:{defenceStat * multiplier}\nLuck:{luckStat * multiplier}\n";
	}
}
