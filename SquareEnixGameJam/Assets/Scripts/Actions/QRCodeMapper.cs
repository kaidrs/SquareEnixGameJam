using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRCodeMapper : MonoBehaviour
{
    Card chosenCard;

    [SerializeField] public SpellCard card;

    public void MapCodeToCard(string QRResult)
    {
        TileType playerTileType = TileManager.Instance.GetMyCurrentTile(PlayerManager.Instance.ownerPlayer.tilePosition);
        int code = int.Parse(QRResult);

        if (code == 141)
        {
            SpellCard spellCard = CardManager.Instance.CallSpellCard(141);
            //PlayerManager.Instance.ownerPlayer.hero.spellCards.Add(spellCard.CardNumber);
            UIManager.Instance.PromptReward(spellCard);
            NetworkManager.Instance.BroadcastUpdateTurn(); // Ends the turn
            return;
        }

        Card myCard = CardManager.Instance.CallCard(code);

        switch (playerTileType)
        {
            case TileType.Loot:
                LootCard lootedCard = myCard as LootCard;
                UIManager.Instance.PromptReward(lootedCard);
                lootedCard.AddStatToPlayer();
                NetworkManager.Instance.BroadcastUpdateTurn(); // Ends the turn
                break;
            case TileType.Spell:
                SpellCard spellCard = myCard as SpellCard;
                UIManager.Instance.PromptReward(spellCard);
                PlayerManager.Instance.ownerPlayer.hero.spellCards.Add(spellCard.CardNumber);
                NetworkManager.Instance.BroadcastUpdateTurn(); // Ends the turn
                break;
            case TileType.Monster:
                MonsterCard monsterCard = myCard as MonsterCard;
                bool battleResult = BattleManager.Instance.PlayerVsMonster(PlayerManager.Instance.ownerPlayer.hero, monsterCard);
                if (battleResult)
                {
                    LootCard rewardCardLooted = CardManager.Instance.GetRandomLoot();
                    UIManager.Instance.PromptReward(rewardCardLooted);
                }
                NetworkManager.Instance.BroadcastUpdateTurn(); // Ends the turn
                break;
        }
        //if (code <= 120)
        //{
        //    chosenCard = CardManager.Instance.CallLootCard(code);

        //    ((LootCard)chosenCard).AddStatToPlayer();
        //    if (InventoryManager.Instance != null)
        //    {
        //        InventoryManager.Instance.InitInventoryUI();
        //    } else
        //    {
        //        Debug.Log("Inventory instance does not exist");
        //    }
        //}

        //else if (code <= 140)
        //{
        //    chosenCard = CardManager.Instance.CallMonsterCard(code);
        //    //BattleManager.Instance.PlayerVsMonster(PlayerManager.Instance.ownerPlayer.hero, ((MonsterCard)chosenCard));
        //}
        //else if (code <= 150)
        //{
        //    chosenCard = CardManager.Instance.CallSpellCard(code);
        //    SpellActions.Instance.AddSpellToUI(card);
        //}
        //else
        //{
        //    chosenCard = CardManager.Instance.CallEventCard(code);
        //}

    }

}
