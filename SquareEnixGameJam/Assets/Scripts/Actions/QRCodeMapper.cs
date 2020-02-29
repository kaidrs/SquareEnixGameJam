using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRCodeMapper : MonoBehaviour
{

    public void MapCodeToCard(string QRResult)
    {

        // Reset the hidden counter for getting random card without scanning.
        GameManager.Instance.randomCardTap = 0;

        TileType playerTileType = TileManager.Instance.GetMyCurrentTile(PlayerManager.Instance.ownerPlayer.tilePosition);
        int code = int.Parse(QRResult);
        Debug.Log($"YOU GOT CARD #{code}");
        #region passTURN
        if (code == 198)
        {
            NetworkManager.Instance.BroadcastUpdateTurn(); // Ends the turn
            return;
        }
        #endregion
        Card myCard = CardManager.Instance.CallCard(code);

        switch (playerTileType)
        {
            case TileType.Loot:
                LootCard lootedCard = myCard as LootCard;
                if (lootedCard != null)
                {
                    UIManager.Instance.PromptReward(lootedCard);
                }
                else
                {
                    UIManager.Instance.PromptMessage("Wrong card scanned! Try again!");
                    UIManager.Instance.PromptGoQR();
                    return;
                }
                NetworkManager.Instance.BroadcastUpdateTurn(); // Ends the turn
                break;
            case TileType.Spell:
                SpellCard spellCard = myCard as SpellCard;
                if (spellCard != null)
                {
                    UIManager.Instance.PromptReward(spellCard);
                    PlayerManager.Instance.ownerPlayer.hero.spellCards.Add(spellCard.CardNumber);
                }
                else
                {
                    UIManager.Instance.PromptMessage("Wrong card scanned! Try again!");
                    UIManager.Instance.PromptGoQR();
                    return;
                }
                NetworkManager.Instance.BroadcastUpdateTurn(); // Ends the turn
                break;
            case TileType.Monster:
                MonsterCard monsterCard = myCard as MonsterCard;
                if (monsterCard != null)
                {
                    UIManager.Instance.PromptBattle(PlayerManager.Instance.ownerPlayer.hero, monsterCard);
                }
                else
                {
                    UIManager.Instance.PromptMessage("Wrong card scanned! Try again!");
                    UIManager.Instance.PromptGoQR();
                    return;
                }
                break;
        }


    }

    /// <summary>
    /// Used to get random card without scanning.
    /// </summary>
    public void OnRandomCardButtonClicked()
    {
        GameManager.Instance.randomCardTap++;
        if (GameManager.Instance.randomCardTap >= 3)
        {
            GameManager.Instance.randomCardTap = 0;
            QRDecodeTest.Instance.Stop();
            TileType playerTileType = TileManager.Instance.GetMyCurrentTile(PlayerManager.Instance.ownerPlayer.tilePosition);
            switch (playerTileType)
            {
                case TileType.Loot:
                    var randomLootCard = CardManager.Instance.GetRandomLoot();
                    MapCodeToCard(randomLootCard.CardNumber.ToString());
                    break;
                case TileType.Spell:
                    var randomSpellCard = CardManager.Instance.GetRandomSpell();
                    MapCodeToCard(randomSpellCard.CardNumber.ToString());
                    break;
                case TileType.Monster:
                    var randomMonsterCard = CardManager.Instance.GetRandomMonster();
                    MapCodeToCard(randomMonsterCard.CardNumber.ToString());
                    break;
                default:
                    break;
            } 
        }
    }

}
