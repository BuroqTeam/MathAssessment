using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropDownP4 : MonoBehaviour/*, IPointerClickHandler*/
{
    public Pattern_4 Pattern4;
    public string AddressToTerm;
    public List<string> StrList /*= new List<string>() { "Tanlang", ">", "<", "=" }*/; 

    public TMP_Dropdown DropDownObj;
    public GameObject DropDownGameObject;
    public Sprite DropDownBlueSprite;
    public Sprite SpriteCornerUp, SpriteCornerDown;

    public string CorrectAnswer;        // boshqa skriptdan buyerga to'g'ri javobni berib olamiz.
    public string CurrentAnswer;

    public string InitialStr;

    void Start()
    {
        PopulateList();
    }
        

    void PopulateList()
    {
        InitialStr = I2.Loc.LocalizationManager.GetTranslation(AddressToTerm);
        StrList = new List<string>() { I2.Loc.LocalizationManager.GetTranslation(AddressToTerm), ">", "<", "=" };
        DropDownObj.AddOptions(StrList);        
    }

    
    public void DropDown_IndexChangedd(int index)
    {
        CurrentAnswer = StrList[index];
        //Debug.Log("  " + StrList[index]);
        DropDownGameObject.GetComponent<Image>().sprite = DropDownBlueSprite;
        DropDownObj.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        DropDownObj.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color = new Color(1, 1, 1, 1);

        DropDownObj.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = SpriteCornerDown;
        
        CheckingAnswer();
    }


    void CheckingAnswer()
    {
        if (CurrentAnswer == CorrectAnswer)        {
            //Debug.Log("To'g'ri javob tanlandi.");
        }
        else if (CurrentAnswer != CorrectAnswer)       {
            //Debug.Log("Noto'g'ri javob tanlandi.");
        }
        Pattern4.CheckAllAnswers();
        Pattern4.Check();
    }


}
