using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    private Text dialogTextBox;
    [SerializeField] private string[] textsToDisplay;
    [SerializeField] private GameObject panel;
    private Touch touch;
    private int currentText = 0;

    public void Start()
    {
        dialogTextBox = gameObject.GetComponent<Text>();
        dialogTextBox.text = textsToDisplay[currentText];
    }

    public void Update()
    {
        TapToContinueText();
    }

    public void TapToContinueText()
    {
        if(touch.phase == TouchPhase.Began && Input.touchCount > 0)
        {
            touch.phase = TouchPhase.Ended;
            NextText();
        }

#if UNITY_EDITOR
        if (Input.anyKeyDown)
        {
            NextText();
        }
#endif
    }

    public void NextText()
    {
        if(currentText < textsToDisplay.Length - 1)
        {
            currentText++;
            dialogTextBox.text = textsToDisplay[currentText];
        }
        else
        {
            panel.SetActive(false);
        }
        Debug.Log(currentText);
    }
}
