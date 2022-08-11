using DG.Tweening;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_16 : GeneralTest
{
    public GameEvent ActNext;
    public GameEvent DeactNext;
    public List<GameObject> ExistentPrefabs = new();
    public List<int> _prefabsIndex;
    private TextAsset _currentJsonText;
    private int _resultValue = 0;
    bool _isTrue = true;
    Data_16 Pattern_16Obj = new();
    private void Start()
    {
        if (Screen.width / Screen.height < 1.5f)
        {
            //Debug.Log("Tablet");
            transform.GetChild(1).GetComponent<RectTransform>().DOScale(0.8f, 0);
            transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPosX(0, 0);
            transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPosY(-80, 0);
        }
    }

    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
            ReadFromJson();
        }
        DisplayQuestion(Pattern_16Obj.title);
    }
    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }
    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_16");
        Pattern_16Obj = jo.ToObject<Data_16>();
        CreatePrefabs();
    }

    public void ReadPrefabsIndex()
    {
        for (int i = 0; i < Pattern_16Obj.problem.Count; i = i + 2)
        {
            int loc_1 = Pattern_16Obj.problem[i].IndexOf("{");
            int loc_1_1 = Pattern_16Obj.problem[i].IndexOf("}");
            string loc_2 = Pattern_16Obj.problem[i].Remove(0, loc_1 + 1);
            string surat = loc_2.Remove(loc_1_1 - (loc_1 + 1), loc_2.Length - (loc_1_1 - (loc_1 + 1)));
            int loc_2_1 = loc_2.IndexOf("{");
            string maxraj = loc_2.Remove(0, loc_2_1 + 1);
            maxraj = maxraj.Remove(maxraj.Length - 1, 1);
            _prefabsIndex.Add(Convert.ToInt32(surat));
            _prefabsIndex.Add(Convert.ToInt32(maxraj));
        }

        //solution`s _prefabIndex
        int loc_11 = Pattern_16Obj.solution[0].IndexOf("{");
        int loc_1_11 = Pattern_16Obj.solution[0].IndexOf("}");
        string loc_21 = Pattern_16Obj.solution[0].Remove(0, loc_11 + 1);
        string surat1 = loc_21.Remove(loc_1_11 - (loc_11 + 1), loc_21.Length - (loc_1_11 - (loc_11 + 1)));
        int loc_2_11 = loc_21.IndexOf("{");
        string maxraj1 = loc_21.Remove(0, loc_2_11 + 1);
        maxraj1 = maxraj1.Remove(maxraj1.Length - 1, 1);
        _prefabsIndex.Add(Convert.ToInt32(surat1));
        _prefabsIndex.Add(Convert.ToInt32(maxraj1));

    }

    public void CreatePrefabs()
    {
        int createPrefabIndex = -1;
        transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_16Obj.problem[0] + "  " + Pattern_16Obj.problem[1] + "  " + Pattern_16Obj.problem[2];
        transform.GetChild(1).GetChild(1).GetComponent<TEXDraw>().text = Pattern_16Obj.problem[1];
        ReadPrefabsIndex();
        for (int i = 1; i < _prefabsIndex.Count; i = i + 2)
        {
            for (int j = 0; j < ExistentPrefabs.Count; j++)
            {
                if (_prefabsIndex[i] == ExistentPrefabs[j].transform.childCount)
                {
                    createPrefabIndex = j;
                }
            }
            GameObject prefab = Instantiate(ExistentPrefabs[createPrefabIndex], transform.GetChild(1).GetChild(i-1).transform);
            if (i<5)
            {
                for (int q = 0; q < _prefabsIndex[i-1]; q++)
                {
                    prefab.transform.GetChild(q).GetComponent<P16_ButtonController>().Selected = true;
                }
                for (int w = 0; w < prefab.transform.childCount; w++)
                {
                    prefab.transform.GetChild(w).GetComponent<Button>().enabled = false;
                }
            }
        }
        
    }

    public void Result()
    {
        _resultValue = 0;
        for (int i = 0; i < transform.GetChild(1).GetChild(4).GetChild(0).childCount; i++)
        {
            if (transform.GetChild(1).GetChild(4).GetChild(0).GetChild(i).GetComponent<P16_ButtonController>().Select == true)
            {
                _resultValue++;
            }
        }
        Debug.Log(_resultValue);
        Debug.Log(_prefabsIndex[_prefabsIndex.Count - 2]);
        if (_resultValue == _prefabsIndex[_prefabsIndex.Count - 2])
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
    }

    public void CheckButton()
    {
        int b = 0;
        for (int i = 0; i < transform.GetChild(1).GetChild(4).GetChild(0).childCount; i++)
        {
            if (transform.GetChild(1).GetChild(4).GetChild(0).GetChild(i).GetComponent<P16_ButtonController>().Select == true)
            {
                b++;
            }
        }
        if (b>0)
        {
            ActNext.Raise();
        }
        else
        {
            DeactNext.Raise();
        }

    }

    public void Check()
    {
        Result();
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        if (_resultValue == _prefabsIndex[_prefabsIndex.Count - 2])
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("myList", currentList);
        ActivateNext();
    }

    void ActivateNext()
    {
        int index = TestManager.Instance.ActivePatterns.FindIndex(o => o == gameObject);
        index++;
        TestManager.Instance.ActivePatterns[index].SetActive(true);
        gameObject.SetActive(false);
    }
}
[SerializeField]
public class Data_16
{
    public string title;
    public List<string> problem;
    public List<string> solution;
}

