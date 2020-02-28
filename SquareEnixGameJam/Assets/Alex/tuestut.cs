using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuestut : MonoBehaviour
{
    public void UpdateTurn()
    {
        NetworkManager.Instance.BroadcastUpdateTurn();
    }
}
