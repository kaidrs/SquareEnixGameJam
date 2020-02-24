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
                UIManager.Instance.PromptReward(lootedCard);
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
                UIManager.Instance.PromptBattle(PlayerManager.Instance.ownerPlayer.hero, monsterCard);
                break;
        }

    }


}
