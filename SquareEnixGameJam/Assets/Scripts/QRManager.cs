using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRManager : MonoBehaviour
{
    [SerializeField] QRScan qrObject;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartQR", 3f);
        //Invoke("killIt", 7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartQR()
    {
        Instantiate(qrObject);
    }

    public void killIt()
    {
        qrObject = FindObjectOfType<QRScan>();
        qrObject.camTexture.Stop();
        Destroy(qrObject);
        Debug.Log("killed");
    }
}
