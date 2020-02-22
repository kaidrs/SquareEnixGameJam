﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/SpellCard")]
public class SpellCard : Card
{
	[Header("Spell Properties")]
	[SerializeField] private int damage;
	[SerializeField] private float heal;

    public void CastSpell(Hero hero = null, Hero otherHero = null)
	{
		if (heal > 0)
		{
			hero.HealthPoint += heal;
			if (hero.HealthPoint > 1.0f)
			{
				hero.HealthPoint = 1.0f;
			}
		}
		if (damage > 0)
		{
			otherHero.HealthPoint -= damage;
		}
	}

	public override string ToString()
	{
		return $"Cardname:{CardName}, CardNumber:{CardNumber}";
	}
}
