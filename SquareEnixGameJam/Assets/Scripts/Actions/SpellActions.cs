using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellActions : MonoBehaviour
{
    [SerializeField] public List<GameObject> spellSlots;
    [SerializeField] private Dictionary<string, int> spellsLookupTable;

    public Sprite defaultSlotImage;


    private void Start()
    {
        if (spellSlots != null)
        {
            spellsLookupTable = new Dictionary<string, int>();
        }
    }

    private int GetNextEmptySlot()
    {
        foreach (GameObject slot in spellSlots)
        {
            Sprite sprite = slot.GetComponent<Image>().sprite;
            if (sprite == defaultSlotImage)
            {
                return spellSlots.IndexOf(slot);
            }
        }
        return -1;
    }

    void AddSpellToUI(SpellCard card)
    {
        int nextEmptySlot = GetNextEmptySlot();

        if (nextEmptySlot >= 0)
        {
            GameObject newSlot = spellSlots[nextEmptySlot];
            newSlot.GetComponent<Image>().sprite = card.CardSprite;
            spellsLookupTable.Add(card.CardName, nextEmptySlot);
        }
        else
        {
            Debug.Log("SpellActions::AddSpellToUI::Spell slots are full!");
        }
    }

    void RemoveSpellFromUI(SpellCard card)
    {
        int nextEmptySlot = GetNextEmptySlot();

        if (nextEmptySlot == -1)
        {
            Debug.Log("SpellActions::RemoveSpellFromUI::Spell slots are empty!");
        }
        else
        {
            GameObject slotToRemove = spellSlots[spellsLookupTable[card.CardName]];
            Sprite spellSprite = slotToRemove.GetComponent<Image>().sprite;
            if (spellSprite == card.CardSprite) // slot is occupied 
            {
                slotToRemove.GetComponent<Image>().sprite = defaultSlotImage;
            }
            spellsLookupTable.Remove(card.CardName);
        }
    }

    void ApplySpell(SpellCard card)
    {
        Debug.Log("Applying spell " + card.CardName);
        card.CastSpell(PlayerManager.Instance.ownerPlayer.hero);
        RemoveSpellFromUI(card);
    }
}
