using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroManager : MonoBehaviour
{
    public static List<string> playerChoice = new List<string>();


    #region Singleton
    private static HeroManager _instance = null;

    public static HeroManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<HeroManager>();
            }
            return _instance;
        }
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickWarrior()
    {
        playerChoice.Add("Warrior");
        GameScene();
    }

    public void PickPaladin()
    {
        playerChoice.Add("Paladin");
        GameScene();
    }

    public void PickThief()
    {
        playerChoice.Add("Thief");
        GameScene();
    }

    public void GameScene()
    {
        SceneManager.LoadScene("AfterSelectionRob");
    }
}
