using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/SpellCard")]
public class SpellCard : Card
{

    public void CastSpell()
	{

	}
	public override string ToString()
	{
		return $"Cardname:{CardName}, CardNumber:{CardNumber}";
	}
}
