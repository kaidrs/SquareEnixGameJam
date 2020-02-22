using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroManager : MonoBehaviour
{
    public static List<Hero> playerChoice = new List<Hero>();


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

        Hero warrior = ScriptableObject.CreateInstance<Warrior>();
        warrior.HealthPoint = 1.0f;
        warrior.AttackPoint = 10;
        warrior.DefencePoint = 5;
        warrior.Luck = 1;
        warrior.ClassText = "Warrior";
        playerChoice.Add(warrior);
        GameScene();
    }

    public void PickPaladin()
    {
        Hero paladin = ScriptableObject.CreateInstance<Paladin>();
        paladin.HealthPoint = 1.0f;
        paladin.AttackPoint = 10;
        paladin.DefencePoint = 5;
        paladin.Luck = 1;
        paladin.ClassText = "Paladin";
        playerChoice.Add(paladin);
        GameScene();
    }

    public void PickThief()
    {
        Hero thief = ScriptableObject.CreateInstance<Thief>();
        thief.HealthPoint = 1.0f;
        thief.AttackPoint = 5;
        thief.DefencePoint = 5;
        thief.Luck = 10;
        thief.ClassText = "Thief";
        playerChoice.Add(thief);
        GameScene();
    }

    public void GameScene()
    {
        SceneManager.LoadScene("AfterSelectionRob");
    }
}
