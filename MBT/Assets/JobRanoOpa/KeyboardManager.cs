using TMPro;
using UnityEngine;

/// <summary>
/// This script is responsible for keyboard.
/// </summary>
public class KeyboardManager : MonoBehaviour
{
    public TMP_InputField inputField; // Sahnadagi InputField
    public string SavedName; // Graphic4 yoki GraphicRasm5;
    private TouchScreenKeyboard keyboard;
    private string _playerP;
    public bool IsFinished = false;

    /// <summary>
    /// In this Event added new actin that started after text writing finished.
    /// </summary>
    //public UnityEvent NextEvent; 

    private void Start()
    {
        CheckText();
    }

    void Update()
    {
        // Klaviaturadagi matnni InputField'ga o‘tkazish
        if (keyboard != null && keyboard.active && inputField.text != keyboard.text)
        {
            inputField.text = keyboard.text;
            //Debug.Log("Two");
        }
    }

    public void ShowKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    private void CheckText()
    {
        _playerP = PlayerPrefs.GetString(SavedName);
        if (_playerP != null)
        {
            inputField.text = _playerP;
        }
    }


    public void SaveText()
    {
        Debug.Log("TextSaved");
        string newString = inputField.text;
        PlayerPrefs.SetString(SavedName, newString);
    }

    public void FinishWritingText()
    {
        Debug.Log("");
    }

    public void TextEnterClicked()
    {   // InputField bosilganda klaviaturani ochish
        if (inputField.isFocused && TouchScreenKeyboard.visible == false && !IsFinished)
        {
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
            //Debug.Log("One");
        }
        Debug.Log("Text enter clicked");
    }

}
