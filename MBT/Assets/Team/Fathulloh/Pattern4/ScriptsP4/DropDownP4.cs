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


    void Start()
    {
        PopulateList();
    }
        

    void PopulateList()
    {
        StrList = new List<string>() { I2.Loc.LocalizationManager.GetTranslation(AddressToTerm), ">", "<", "=" };
        DropDownObj.AddOptions(StrList);        
    }

    //bool _IsFirstTime = true;
    public void DropDown_IndexChangedd(int index)
    {
        CurrentAnswer = StrList[index];
        //Debug.Log("  " + StrList[index]);
        DropDownGameObject.GetComponent<Image>().sprite = DropDownBlueSprite;
        DropDownObj.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        DropDownObj.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color = new Color(1, 1, 1, 1);

        DropDownObj.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = SpriteCornerDown;
        //if (_IsFirstTime)        {
        //    _IsFirstTime = false;
        //    DropDownObj.ClearOptions();
        //    StrList = new List<string>() {">", "<", "=" };
        //    DropDownObj.AddOptions(StrList);
        //}
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
    }


    
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    //DropDownObj.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = SpriteCornerUp;
    //    //Debug.Log(888);
    //}
}
