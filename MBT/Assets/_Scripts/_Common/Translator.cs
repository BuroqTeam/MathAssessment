using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Translator : MonoBehaviour
{
    [Header("Localization Category")]
    public string AddressToTerm;


    private void Awake()
    {
        SetText();


    }


    void SetText()
    {
        if (GetComponent<TMP_Text>() != null)
        {           
            GetComponent<TMP_Text>().text = I2.Loc.LocalizationManager.GetTranslation(AddressToTerm);
        }
        else if (GetComponent<Text>() != null)
        {
            GetComponent<Text>().text = I2.Loc.LocalizationManager.GetTranslation(AddressToTerm);
        }

    }

    public void UpdateTextTerm(string newTerm)
    {
        AddressToTerm = newTerm;
        SetText();
    }


}
