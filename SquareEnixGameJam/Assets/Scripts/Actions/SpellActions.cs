using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellActions : MonoBehaviour
{
    [SerializeField] public List<GameObject> spellSlots;
    [SerializeField] public Dictionary<int, int> spellsLookupTable; // { spellSlot index, spell card number }

    private string defaultSlotImage = "Background";
    public Sprite defaultSprite;
    private int availableSlots;

    #region Singleton
    private static SpellActions _instance;

    public static SpellActions Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SpellActions>();
            }
            return _instance;
        }
    }
    #endregion


    private void Start()
    {
        if (spellSlots != null)
        {
            spellsLookupTable = new Dictionary<int, int>();
            availableSlots = spellSlots.Count;

            // Populate the spell slots with spells the player owns
            PopulatePlayerSpells();
        }
    }

    public void PopulatePlayerSpells()
    {
        var playerSpells = PlayerManager.Instance.ownerPlayer.hero.spellCards;
        if (playerSpells != null && playerSpells.Count > 0)
        {
            foreach (int spellNum in playerSpells)
            {
                AddSpellToUI(CardManager.Instance.CallSpellCard(spellNum));
            }
        }
    }

    private int GetNextEmptySlot()
    {
        if (availableSlots == 0)
        {
            return -1;
        }

        foreach (GameObject slot in spellSlots)
        {
            Sprite sprite = slot.GetComponent<Image>().sprite;

            if (sprite.name == defaultSlotImage)
            {
                return spellSlots.IndexOf(slot);
            }
        }
        return -1;
    }

    public void AddSpellToUI(SpellCard card)
    {
        // int nextEmptySlot = GetNextEmptySlot();
        int nextEmptySlot = spellSlots.Count - availableSlots;

        if (nextEmptySlot >= 0)
        {
            GameObject newSlot = spellSlots[nextEmptySlot];
            newSlot.GetComponent<Image>().sprite = card.CardSprite;
            try
            {
                spellsLookupTable.Add(nextEmptySlot, card.CardNumber);
            } catch (System.Exception e)
            {
                Debug.Log("Lookup: " + spellsLookupTable[nextEmptySlot]);
            } finally
            {
                Debug.Log("Lookup: " + spellsLookupTable[nextEmptySlot]);
            }
        }
        else
        {
            Debug.Log("SpellActions::AddSpellToUI::Spell slots are full!");
        }
    }

    public void RemoveSpellFromUI(SpellCard card)
    {
        int nextEmptySlot = GetNextEmptySlot();

        if (nextEmptySlot == -1)
        {
            Debug.Log("SpellActions::RemoveSpellFromUI::Spell slots are empty!");
        }
        else
        {
            int slotIndex = 0;
            foreach (KeyValuePair<int, int> keyValue in spellsLookupTable)
            {
                if (keyValue.Value == card.CardNumber)
                {
                    slotIndex = keyValue.Key;
                }
            }

            GameObject slotToRemove = spellSlots[slotIndex];
            Sprite spellSprite = slotToRemove.GetComponent<Image>().sprite;
            if (spellSprite == card.CardSprite) // slot is occupied 
            {
                slotToRemove.GetComponent<Image>().sprite = defaultSprite;
            }
            spellsLookupTable.Remove(slotIndex);
        }
    }

    public void ApplySpell(SpellCard card)
    {
        Debug.Log("Applying spell " + card.CardName);
        card.CastSpell(PlayerManager.Instance.ownerPlayer.hero);
        RemoveSpellFromUI(card);
    }
}
