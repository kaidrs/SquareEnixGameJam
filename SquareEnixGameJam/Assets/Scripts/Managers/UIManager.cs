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
    [SerializeField] GameObject BattleCanvas;
    [SerializeField] GameObject p1SpriteObject;
    [SerializeField] GameObject p2SpriteObject;
    [SerializeField] Slider p1HpSlider;
    [SerializeField] Slider p2HpSlider;//
    [SerializeField] Text p1Text;
    [SerializeField] Text p2Text;

    //Prompt
    [SerializeField] GameObject promptPanel;
    [SerializeField] Text promptText;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
