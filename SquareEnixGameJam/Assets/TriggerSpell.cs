using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSpell : MonoBehaviour
{
    public void TriggerThisSpell()
    {
        GameObject slot = transform.parent.gameObject;
        int indexOfSlot = SpellActions.Instance.spellSlots.IndexOf(slot);
        int spellNumber = SpellActions.Instance.spellsLookupTable[indexOfSlot];
        SpellActions.Instance.ApplySpell(CardManager.Instance.CallSpellCard(spellNumber));
    }
}
