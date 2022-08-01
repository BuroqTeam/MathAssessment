using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DropDownP4 : MonoBehaviour
{
    public List<string> StrList /*= new List<string>() { "Tanlang", ">", "<", "=" }*/; 

    public TMP_Dropdown DropDownObj;
    public GameObject DropDownGameObject;
    public Sprite DropDownBlueSprite;

    public string currentText;
    public UnityEvent ClickEvent;


    void Start()
    {
        //DropDownObj.GetComponent<Dropdown>()
        PopulateList();
    }
        

    void PopulateList()
    {
        StrList = new List<string>() { "Tanlang", ">", "<", "=" };
        DropDownObj.AddOptions(StrList);
        //DropDown.itemImage.sprite = DropDownSprite;
        Debug.Log("------------");
    }

    bool _IsFirstTime = true;
    public void DropDown_IndexChangedd(int index)
    {
        currentText = StrList[index];
        Debug.Log("  " + StrList[index]);
        DropDownGameObject.GetComponent<Image>().sprite = DropDownBlueSprite;
        DropDownObj.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        DropDownObj.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color = new Color(1, 1, 1, 1);

        if (_IsFirstTime)        {
            _IsFirstTime = false;
            DropDownObj.ClearOptions();
            StrList = new List<string>() {">", "<", "=" };
            DropDownObj.AddOptions(StrList);
        }

    }

    public void DDOnValueChange()
    {
        Debug.Log("Drop Down On Value Change! ");

        //DropDownObj.OnPointerClick();
    }


    void DropDownIsClicked()
    {
        Debug.Log("Drop down is clicked.");
    }


    public void OnPointerClick()
    {

    }






}
