using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_6 : MonoBehaviour
{
    private TextAsset _currentJsonText;
    bool _isTrue = true;
    Data_6 Pattern_6Obj = new Data_6();
    private void Awake()
    {
        GetComponent<RectTransform>().anchorMin = new(0, 0);
        GetComponent<RectTransform>().anchorMax = new(1, 1);
        GetComponent<RectTransform>().offsetMin = new(0, 0);
        GetComponent<RectTransform>().offsetMax = new(0, 0);
    }
    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
            if (_currentJsonText != null)
            {
                Debug.Log(_currentJsonText.text);
            }
            else
            {
                Debug.Log("Not Found Data");
            }
            ReadFromJson();
        }
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_6");
        Pattern_6Obj = jo.ToObject<Data_6>();
        transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_6Obj.problem[0];
    }
    public void Result()
    {
        if (transform.GetChild(1).GetChild(0).GetComponent<TEXDraw>().text == Pattern_6Obj.solution[0])
        {
            Debug.Log("Correct");
        }
    }
    void Check()
    {
        Result();
        List<bool> myList = new List<bool>();
        ES3.Save("ResultList", myList);
        List<bool> currentList = new List<bool>();
        currentList = ES3.Load<List<bool>>("ResultList");
        if (transform.GetChild(1).GetChild(0).GetComponent<TEXDraw>().text == Pattern_6Obj.solution[0])
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("myList", currentList);
    }
}

[SerializeField]
public class Data_6
{
    public string title;
    public List<string> problem;
    public List<string> solution;
}

