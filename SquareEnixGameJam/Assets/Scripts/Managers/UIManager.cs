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
    #endregion

    [SerializeField] GameObject InventoryCanvas;
    [SerializeField] GameObject QRScanCanvas;
    [SerializeField] GameObject CameraPlane;

    //Battle
    [Header("BattleUI")]
    [SerializeField] GameObject BattleCanvas;
    [SerializeField] GameObject p1SpriteObject;
    [SerializeField] GameObject p2SpriteObject;
    [SerializeField] Slider p1HpSlider;
    [SerializeField] Slider p2HpSlider;//
    [SerializeField] Text p1Text;
    [SerializeField] Text p2Text;

    [Header("PromptUI")]
    [SerializeField] GameObject promptCanvas;
    [SerializeField] GameObject promptBattle;
    [SerializeField] Text promptBattleText;
    //[SerializeField] GameObject battlePlayer;
    //[SerializeField] GameObject battleOpponent;
    [SerializeField] GameObject promptMessage;
    [SerializeField] Text promptMessageText;
    [SerializeField] GameObject promptReward;
    [SerializeField] Image rewardImage;
    [SerializeField] Text promptRewardText;



    //[SerializeField] Animator promptAnim;

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
    }

    public void ShowBattle(Player player, Player player2)
    {
        InventoryCanvas.SetActive(false);
        BattleCanvas.SetActive(true);
    }

    public void ShowBattle(Player player, MonsterCard monster)
    {
        InventoryCanvas.SetActive(false);
        BattleCanvas.SetActive(true);
    }

    public void PromptMessage(string msg)
    {
        promptMessage.SetActive(true);
        promptMessage.GetComponent<Animator>().Play("PromptIn");
        promptMessageText.text = msg;

    }

    public void PromptReward(int num)
    {

    }

    public void ClosePrompt()
    {
        promptCanvas.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        PromptMessage("Hey");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
