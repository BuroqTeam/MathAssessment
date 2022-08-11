using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropDownP9 : MonoBehaviour
{
    public Pattern_9 Pattern9;
    public string AddressToTerm;

    public List<string> StrList /*= new List<string>() { "Tanlang", ">", "<", "=" }*/;

    public TMP_Dropdown DropDownObj;
    public GameObject DropDownGameObject;
    public Sprite DropDownBlueSprite;
    public Sprite SpriteCornerUp, SpriteCornerDown;

    public string CorrectAnswer;        // boshqa skriptdan buyerga to'g'ri javobni berib olamiz.
    public string CurrentAnswer;
    //bool _IsFirstTime = true;


    void Start()
    {
        PopulateList();
    }


    /// <summary>
    /// DropDownning optionniga elementlarni qo'shib beruvchi kod.
    /// </summary>
    void PopulateList()
    {
        StrList = new List<string>() { I2.Loc.LocalizationManager.GetTranslation(AddressToTerm), ">", "<", "=" };
        DropDownObj.AddOptions(StrList);
    }

    
    /// <summary>
    /// Qiymat o'zgarganda ishlovchi metod. Bu metod ishlaganda tanlangan qiymat currentAnswerga yoziladi.
    /// </summary>
    /// <param name="index"></param>
    public void DropDown_IndexChangedd(int index)
    {        
        CurrentAnswer = StrList[index];
        Debug.Log("index = " + index + "  " + StrList[index]);
        DropDownGameObject.GetComponent<Image>().sprite = DropDownBlueSprite;
        DropDownObj.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        DropDownObj.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color = new Color(1, 1, 1, 1);

        DropDownObj.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = SpriteCornerDown;
        //if (_IsFirstTime)        {
        //    _IsFirstTime = false;
        //    DropDownObj.ClearOptions();
        //    StrList = new List<string>() { ">", "<", "=" };
        //    DropDownObj.AddOptions(StrList);
        //    DropDownObj.captionText.text = CurrentAnswer;
        //    //DropDownObj.options.RemoveAt(0);
        //    //DropDownObj.OnSelect(DropDownObj.options[1]);   
        //}
        
        CheckingAnswer();
    }



    void CheckingAnswer()
    {
        if (CurrentAnswer == CorrectAnswer)        {
            Debug.Log("To'g'ri javob tanlandi.");
        }
        else if (CurrentAnswer != CorrectAnswer)        {
            Debug.Log("Noto'g'ri javob tanlandi.");
        }

        Pattern9.CheckAllAnswers();
    }

        
}
