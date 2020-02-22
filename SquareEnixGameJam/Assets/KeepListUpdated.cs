using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepListUpdated : MonoBehaviour
{
    public Text textList;

    // Update is called once per frame
    void Update()
    {
        textList.text = NetworkManager.Instance.playersNames;
    }
}
