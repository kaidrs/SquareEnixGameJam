using System.Collections;
using System.Collections.Generic;
using ZXing;
using ZXing.QrCode;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QRScan : MonoBehaviour
{

    bool runningCam;
    public Text scanText;
    public WebCamTexture camTexture;
    private Rect screenRect;
    void Start()
    {
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        camTexture = new WebCamTexture();
        //stopTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height;
        camTexture.requestedWidth = Screen.width;
        if (camTexture != null)
        {
            camTexture.Play();
            runningCam = true;
        }
    }

    void OnGUI()
    {
        if (runningCam && camTexture!= null)
        {
            // drawing the camera on screen
            GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleToFit);
            // do the reading — you might want to attempt to read less often than you draw on the screen for performance sake
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                // decode the current frame
                var result = barcodeReader.Decode(camTexture.GetPixels32(),
                  camTexture.width, camTexture.height);
                if (result != null)
                {
                    Debug.Log("DECODED TEXT FROM QR: " + result.Text);
                    scanText.text = result.Text;

                    //camTexture.Stop();
                    runningCam = false;
                    FindObjectOfType<QRManager>().killIt();


                }

            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
        }
        
    }
}
