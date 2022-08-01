using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using I2.Loc;

public class LanguageManager : MonoBehaviour
{
	void OnEnable()
	{
		
		var dropdown = GetComponent<TMP_Dropdown>();
		if (dropdown == null)
			return;

		var currentLanguage = LocalizationManager.CurrentLanguage;
		if (LocalizationManager.Sources.Count == 0) LocalizationManager.UpdateSources();
        var languages = LocalizationManager.GetAllLanguages();

        //Fill the dropdown elements
		
        //dropdown.ClearOptions();
        //dropdown.AddOptions(languages);

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
		
	}





}
