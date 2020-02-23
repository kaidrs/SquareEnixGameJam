using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAddManager : MonoBehaviour
{
    #region Singleton
    private static SceneAddManager _instance = null;
    public static SceneAddManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SceneAddManager>();
            }
            return _instance;
        }
    }
    #endregion

    public string sceneName;
    private AsyncOperation async;

    private void Start()
    {
        LoadMinigameScene(sceneName);
    }
    public void LoadMinigameScene(string sceneName)
    {
        async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        if (async != null)
        {
            async.allowSceneActivation = true;
        }
        else
        {
            Debug.Log("No Scene found");
        }
    }
}
