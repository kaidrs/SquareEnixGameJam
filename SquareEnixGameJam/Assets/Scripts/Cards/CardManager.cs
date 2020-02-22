using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardManager : MonoBehaviour
{

    #region Singleton

    static CardManager instance = null;
  
    CardManager GetInstance()
    {
        if (instance == null)
        {
            instance = this;
        }

        return instance;
    }

    #endregion

    private CardManager()
    {

    }
}
