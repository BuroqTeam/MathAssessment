using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is responsible for keyboard. 
/// 
/// </summary>
public class KeyboardManager : MonoBehaviour
{
    public TMP_InputField inputField; // Sahnadagi InputField
    private TouchScreenKeyboard keyboard;
    string playerP;

    private void Start()
    {
        CheckText();
    }

    void Update()
    {
        // InputField bosilganda klaviaturani ochish
        if (inputField.isFocused && TouchScreenKeyboard.visible == false)
        {
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
            //Debug.Log("One");
        }

        // Klaviaturadagi matnni InputField'ga o‘tkazish
        if (keyboard != null && keyboard.active && inputField.text != keyboard.text)
        {
            inputField.text = keyboard.text;
            //Debug.Log("Two");
        }
    }


    private void CheckText()
    {
        playerP = PlayerPrefs.GetString("Graphic4");
        if (playerP != null)
        {
            inputField.text = playerP;
        }
    }


    public void SaveText()
    {
        Debug.Log("TextSaved");
        string newString = inputField.text;
        PlayerPrefs.SetString("Graphic4", newString);
    }


    public void TextEnterClicked()
    {
        Debug.Log("Text enter clicked");
    }

}
