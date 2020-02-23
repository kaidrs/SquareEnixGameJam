using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance = null;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }
            return _instance;
        }
    }

    public Slider P1HpSlider { get => p1HpSlider; set => p1HpSlider = value; }
    public Slider P2HpSlider { get => p2HpSlider; set => p2HpSlider = value; }
    public Hero PlayerHolder { get => playerHolder; set => playerHolder = value; }
    public Hero PlayerHolder2 { get => playerHolder2; set => playerHolder2 = value; }
    #endregion


    Hero playerHolder;
    Hero playerHolder2;

    [SerializeField] Camera QRCamera;
    [SerializeField] GameObject InventoryCanvas;
    [SerializeField] GameObject QRScanCanvas;
    [SerializeField] GameObject CameraPlane;

    //Battle
    [Header("BattleUI")]
    [SerializeField] GameObject BattleCanvas;
    [SerializeField] Image p1SpriteObject;
    [SerializeField] Image p2SpriteObject;
    [SerializeField] Slider p1HpSlider;
    [SerializeField] Slider p2HpSlider;//
    [SerializeField] Text p1Text;
    [SerializeField] Text p2Text;
    public bool inBattle;


    [Header("PromptUI")]
    [SerializeField] GameObject promptCanvas;
    [SerializeField] GameObject promptBattle;
    [SerializeField] Text promptBattleText;
    [SerializeField] Button battleEngageBtn;
    [SerializeField] Button battleRetreatBtn;
    [SerializeField] GameObject battleSpellPanel;
    //[SerializeField] GameObject battlePlayer;
    //[SerializeField] GameObject battleOpponent;
    [SerializeField] GameObject promptMessage;
    [SerializeField] Text promptMessageText;
    [SerializeField] GameObject promptReward;
    [SerializeField] Image rewardImage;
    [SerializeField] Text promptRewardText;
    //[SerializeField] Animator promptAnim;

    [Header("Inventory Canvas")]
    public Color yourTurn = Color.green;
    public Color waitTurn = Color.red;
    public Image currentTurnPanel;
    public Button diceButton;

    public void ShowQR()
    {
        InventoryCanvas.SetActive(false);
        QRScanCanvas.SetActive(true);
        CameraPlane.SetActive(true);
    }

    public void ShowInventory()
    {
        InventoryCanvas.SetActive(true);
        QRScanCanvas.SetActive(false);
        CameraPlane.SetActive(false);
        QRCamera.enabled = true;
    }



    public void PromptBattle(Hero player, Hero player2)
    {
        promptBattle.SetActive(true);
        promptBattleText.text = "Encountered a Player! Choose to battle?";
        promptBattle.GetComponent<Animator>().Play("promptBattle");
        battleRetreatBtn.enabled = true;
        p1SpriteObject.sprite = player.heroSprite;
        p2SpriteObject.sprite = player2.heroSprite;

        PlayerHolder = player;
        PlayerHolder2 = player2;


        //DoBattle();


    }

    public void PromptBattle(Hero player, MonsterCard monster)
    {
        promptBattle.SetActive(true);
        promptBattleText.text = "Encountered a Monster! Prepare to engage!";
        promptBattle.GetComponent<Animator>().Play("promptBattle");
        battleRetreatBtn.enabled = false;
        BattleCanvas.GetComponent<Canvas>().enabled = false;
        p1SpriteObject.sprite = player.heroSprite;
        p2SpriteObject.sprite = monster.CardSprite;
       
        //DoBattle();
    }

    public void PromptBattleSpellBar(Hero myHero)
    {
       // myHero.spellCards
    }

    //Called later if time
    public void DoBattle()
    {
        inBattle = true;
        BattleCanvas.GetComponent<Canvas>().enabled = true;
        InventoryCanvas.SetActive(false);
        BattleManager.Instance.PlayerVsPlayer(PlayerHolder, PlayerHolder2);
        // BattleCanvas.SetActive(true);
        //promptBattle.GetComponent<Animator>().Play("promptBattle");
    }

    public void DontDoBattle()
    {
        TileManager.Instance.VerifyPlayerTilePosition();
    }

    public void PromptMessage(string msg)
    {
        promptMessage.SetActive(true);
        promptMessage.GetComponent<Animator>().Play("PromptMessageIn");
        promptMessageText.text = msg;

    }

    public void PromptReward(Card card)
    {
        promptReward.SetActive(true);
        rewardImage.sprite = card.CardSprite;
        promptRewardText.text = "You have received " + card.CardName + " !";
        if (card is SpellCard)
        {
            SpellActions.Instance.AddSpellToUI(card as SpellCard);
        }
        InventoryManager.Instance.InitInventoryUI();
    }

    public void HidePrompts()
    {
        promptReward.SetActive(false);
        promptMessage.SetActive(false);
        promptBattle.SetActive(false);
        BattleCanvas.SetActive(false);

    }

    //public void PromptRewardSpell(Card card)
    //{
        
    //}

    public void ClosePrompt()
    {
        promptCanvas.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        // PromptMessage("hi");
        EnableTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDice()
    {
        InventoryCanvas.SetActive(false);
        QRScanCanvas.SetActive(false);
        CameraPlane.SetActive(false);
        HidePrompts();
        QRCamera.enabled = false;
        DiceManager.Instance.diceScript.RollDice();
    }

    public void PromptGoQR()
    {
        Debug.Log("we cool");
        QRDecodeTest.Instance.Play();
    }

    public void EnableTurn()
    {
        bool myTurn = PlayerManager.Instance.IsCurrent;
        if (myTurn)
        {
            currentTurnPanel.color = yourTurn;
            diceButton.interactable = true;
            foreach (var spellSlot in SpellActions.Instance.spellSlots)
            {
                spellSlot.GetComponent<Button>().interactable = true;
            }
            Debug.Log("Your Turn");
        }
        else
        {
            currentTurnPanel.color = waitTurn;
            diceButton.interactable = false;
            foreach (var spellSlot in SpellActions.Instance.spellSlots)
            {
                spellSlot.GetComponent<Button>().interactable = false;
            }
            Debug.Log("Wait Turn");
        }
    }

 
}
