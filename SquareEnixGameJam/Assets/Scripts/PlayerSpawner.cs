using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        string prefabName = playerPrefab.name;
        PhotonNetwork.Instantiate(prefabName, Vector3.zero, Quaternion.identity);
    }
}
