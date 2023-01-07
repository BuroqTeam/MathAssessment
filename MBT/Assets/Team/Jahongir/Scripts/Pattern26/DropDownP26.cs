using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropDownP26 : MonoBehaviour
{
    public Pattern_26 Pattern26;

    public List<string> StrList /*= new List<string>() { "Tanlang", ">", "<", "=" }*/;

    public TMP_Dropdown DropDownObj;
    public GameObject DropDownGameObject;
    public Sprite DropDownBlueSprite;
    public Sprite DropDownNonActiveSprite;
    public Sprite SpriteCornerUp, SpriteCornerDown;

    public string CorrectAnswer;        // boshqa skriptdan buyerga to'g'ri javobni berib olamiz.
    public string CurrentAnswer;


    void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {
        DropDownObj.AddOptions(StrList);
    }

    public void DropDown_IndexChangedd(int index)
    {
        CurrentAnswer = StrList[index];
        DropDownGameObject.GetComponent<Image>().sprite = DropDownBlueSprite;
        DropDownObj.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        DropDownObj.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color = new Color(1, 1, 1, 1);

        DropDownObj.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = SpriteCornerDown;

        CheckingAnswer();
    }

    public void DropDownNonActive()
    {
        //Logging.Log("index = " + index + "  " + StrList[index]);
        DropDownGameObject.GetComponent<Image>().sprite = DropDownNonActiveSprite;
        DropDownObj.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(0, 0.6f, 1, 1);
        DropDownObj.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color = new Color(0, 0.6f, 1, 1);

        DropDownObj.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = SpriteCornerDown;
    }

    void CheckingAnswer()
    {
        Pattern26.CheckAllAnswers();
        Pattern26.Check();
    }
}
