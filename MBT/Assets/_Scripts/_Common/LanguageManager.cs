using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using I2.Loc;
using UnityEngine.Events;

public class LanguageManager : MonoBehaviour
{

    public UnityEvent LanguageSwitched;

    private void Awake()
    {
        string str = LocalizationManager.CurrentLanguage;
        str = str.ToLower();
        if (str.Length == 0)
            Debug.Log("Empty String");
        else if (str.Length == 1)
            ES3.Save<string>("LanguageKey", char.ToUpper(str[0]).ToString());            
        else
            ES3.Save<string>("LanguageKey", char.ToUpper(str[0]) + str.Substring(1));
       
        
    }

    void OnEnable()
	{		
		var dropdown = GetComponent<TMP_Dropdown>();
		if (dropdown == null)
			return;

		var currentLanguage = LocalizationManager.CurrentLanguage;
		if (LocalizationManager.Sources.Count == 0) LocalizationManager.UpdateSources();
        var languages = LocalizationManager.GetAllLanguages();

        dropdown.value = languages.IndexOf(currentLanguage);
        dropdown.onValueChanged.RemoveListener(OnValueChanged);
		dropdown.onValueChanged.AddListener(OnValueChanged);
	}

	void OnValueChanged(int index)
	{
        switch (index)
        {
            case 0:
                ES3.Save<string>("LanguageKey", "Uzb");
                break;
            case 1:
                ES3.Save<string>("LanguageKey", "Kar");
                break;
            case 2:
                ES3.Save<string>("LanguageKey", "Kaz");
                break;
            case 3:
                ES3.Save<string>("LanguageKey", "Kir");
                break;
            case 4:
                ES3.Save<string>("LanguageKey", "Tjk");
                break;
            case 5:
                ES3.Save<string>("LanguageKey", "Trk");
                break;
            case 6:
                ES3.Save<string>("LanguageKey", "Rus");
                break;
        }

        var dropdown = GetComponent<TMP_Dropdown>();
		if (index < 0)
		{
			index = 0;
			dropdown.value = index;
		}                
		LocalizationManager.CurrentLanguage = dropdown.options[index].text;
        LanguageSwitched.Invoke();

    }





}
