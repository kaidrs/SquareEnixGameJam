using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSpell : MonoBehaviour
{
    public void TriggerThisSpell()
    {
        GameObject slot = transform.gameObject;

        int indexOfSlot = SpellActions.Instance.spellSlots.IndexOf(slot);
        if (SpellActions.Instance.spellsLookupTable.Count == 0)
        {
            return;
        }
        int spellNumber = SpellActions.Instance.spellsLookupTable[indexOfSlot];
        SpellCard card = CardManager.Instance.CallSpellCard(spellNumber);
        Debug.Log("TriggerThisSpell:: spellNumber " + spellNumber);
        Debug.Log("TriggerThisSpell:: card " + card.CardName);
        SpellActions.Instance.ApplySpell(CardManager.Instance.CallSpellCard(spellNumber));
    }
}
