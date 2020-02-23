using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRCodeMapper : MonoBehaviour
{
    Card chosenCard;

    [SerializeField] public SpellCard card;

    public void MapCodeToCard(string QRResult)
    {
        int code = int.Parse(QRResult);

        if (code <= 120)
        {
            chosenCard = CardManager.Instance.CallLootCard(code);

            ((LootCard)chosenCard).AddStatToPlayer(PlayerManager.Instance.ownerPlayer.hero);
            if (InventoryManager.Instance != null)
            {
                InventoryManager.Instance.InitInventoryUI();
            } else
            {
                Debug.Log("Inventory instance does not exist");
            }
        }

        else if (code <= 140)
        {
            chosenCard = CardManager.Instance.CallMonsterCard(code);
            //BattleManager.Instance.PlayerVsMonster(PlayerManager.Instance.ownerPlayer.hero, ((MonsterCard)chosenCard));
        }
        else if (code <= 150)
        {
            chosenCard = CardManager.Instance.CallSpellCard(code);
            InventoryManager.Instance.PopulateSpell(card);
        }
        else
        {
            chosenCard = CardManager.Instance.CallEventCard(code);
        }

    }

}
