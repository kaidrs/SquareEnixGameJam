using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRCodeMapper : MonoBehaviour
{
    Card chosenCard;

    public void MapCodeToCard(string QRResult)
    {
        int code = int.Parse(QRResult);

        if (code <= 120)
        {
            chosenCard = CardManager.Instance.CallLootCard(code);
            //Hero currentHero = new Hero(1,1,1,1);
            Debug.Log(InventoryManager.Instance);

            //if (currentHero != null)
            //{
            //    ((LootCard)chosenCard).AddStatToPlayer(currentHero);
            //    InventoryManager.Instance.InitInventoryUI();
            //    Debug.Log("Hero attack stats: " + currentHero.AttackPoint);
            //    Debug.Log("Hero defense stats: " + currentHero.DefencePoint);
            //    Debug.Log("Hero luck stats: " + currentHero.Luck);
            //}
            //else
            //{
            //    Debug.Log("QRCodeMapper: No hero found");
            //}
            
            
        } else if (code <= 140)
        {
            chosenCard = CardManager.Instance.CallMonsterCard(code);
        } else if (code <= 150)
        {
            chosenCard = CardManager.Instance.CallSpellCard(code);

        } else
        {
            chosenCard = CardManager.Instance.CallEventCard(code);
        }

        Debug.Log("Found card name is =================" + chosenCard.CardName);
    }

}
