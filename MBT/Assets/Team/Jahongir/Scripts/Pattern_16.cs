using DG.Tweening;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pattern_16 : GeneralTest
{
    public GameEvent FinishEvent;
    public List<GameObject> ExistentPrefabs = new();
    public List<GameObject> ActivePrefabs = new();
    public List<GameObject> Operations = new();
    public GameObject _operation1;
    private GameObject _resultPrefab;
    public List<int> _prefabsIndex;
    private TextAsset _currentJsonText;
    private int _resultValue = 0;
    bool _isTrue = true;
    Data_16 Pattern_16Obj = new();
    

    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
            ReadFromJson();
        }
        for (int i = 0; i < ActivePrefabs.Count; i++)
        {
            ActivePrefabs[i].SetActive(true);
        }
        for (int i = 0; i < Operations.Count; i++)
        {
            Operations[i].SetActive(true);
        }
        DisplayQuestion(Pattern_16Obj.title);
        if (ES3.Load<bool>("Pattern_16_Check"))
        {
            
        }
        else
        {
            
        }
    }
    private void OnDisable()
    {
        if (ActivePrefabs.Count>0)
        {
            for (int i = 0; i < ActivePrefabs.Count; i++)
            {
                ActivePrefabs[i].SetActive(false);
            }
            for (int i = 0; i < Operations.Count; i++)
            {
                Operations[i].SetActive(false);
            }

        }
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
        GameObject operation1 = Instantiate(_operation1);
        GameObject operation2 = Instantiate(_operation1);
        Operations.Add(operation1);
        Operations.Add(operation2);
        operation1.GetComponent<TMP_Text>().text = Pattern_16Obj.problem[1];
        operation2.GetComponent<TMP_Text>().text = "=";

        for (int i = 1; i < _prefabsIndex.Count; i = i + 2)
        {
            for (int j = 0; j < ExistentPrefabs.Count; j++)
            {
                if (_prefabsIndex[i] == ExistentPrefabs[j].transform.childCount-1)
                {
                    createPrefabIndex = j;
                }
            }
            GameObject prefab = Instantiate(ExistentPrefabs[createPrefabIndex]);
            if (Screen.width / Screen.height >= 2)
            {
                prefab.GetComponent<Transform>().DOScale(0.9f, 0);
                prefab.GetComponent<Transform>().DOMoveX(-7 + i / 2 * 7, 0);
                prefab.GetComponent<Transform>().DOMoveY(-2.5f, 0);
                transform.GetChild(1).GetChild(1).GetComponent<RectTransform>().DOAnchorPosX(630, 0);
                transform.GetChild(1).GetChild(3).GetComponent<RectTransform>().DOAnchorPosX(1315, 0);
                transform.GetChild(1).GetChild(1).GetComponent<RectTransform>().DOAnchorPosY(-280, 0);
                transform.GetChild(1).GetChild(3).GetComponent<RectTransform>().DOAnchorPosY(-280, 0);
                operation1.GetComponent<RectTransform>().DOAnchorPosX(-3.5f, 0);
                operation1.GetComponent<RectTransform>().DOAnchorPosY(-2.5f, 0);
                operation2.GetComponent<RectTransform>().DOAnchorPosX(3.5f, 0);
                operation2.GetComponent<RectTransform>().DOAnchorPosY(-2.5f, 0);
            }
            else 
            {
                prefab.transform.DOScale(0.5f, 0);
                prefab.transform.DOMoveX(-4.5f + i / 2 * 4.5f, 0);
                prefab.transform.DOMoveY(-2.5f, 0);
                transform.GetChild(1).GetChild(1).GetComponent<RectTransform>().DOAnchorPosX(-255, 0);
                transform.GetChild(1).GetChild(1).GetComponent<RectTransform>().DOAnchorPosY(-50, 0);
                transform.GetChild(1).GetChild(3).GetComponent<RectTransform>().DOAnchorPosX(230, 0);
                transform.GetChild(1).GetChild(3).GetComponent<RectTransform>().DOAnchorPosY(-50, 0);
                operation1.GetComponent<RectTransform>().DOAnchorPosX(-2.2f, 0);
                operation1.GetComponent<RectTransform>().DOAnchorPosY(-2.5f, 0);
                operation2.GetComponent<RectTransform>().DOAnchorPosX(2.25f, 0);
                operation2.GetComponent<RectTransform>().DOAnchorPosY(-2.5f, 0);
            }
            for (int j = 0; j < prefab.transform.childCount - 1; j++)
            {
                prefab.transform.GetChild(j).GetComponent<Uchburchak>().Pattern16 = this;
            }
            if (i < 5)
            {
                for (int q = 0; q < _prefabsIndex[i - 1]; q++)
                {
                    prefab.transform.GetChild(q).GetComponent<Uchburchak>().Selected = true;
                }
                for (int h = 0; h < prefab.transform.childCount - 1; h++)
                {
                    prefab.transform.GetChild(h).GetComponent<PolygonCollider2D>().enabled = false;
                }
            }
            else
            {
                _resultPrefab = prefab;

            }
            ActivePrefabs.Add(prefab);
        }

        
        //operation1.transform.position = Vector3.Lerp(ActivePrefabs[1].transform.position, ActivePrefabs[0].transform.position, 0.5f);
        //Operations.Add(operation1);//operation2.transform.position = Vector3.Lerp(ActivePrefabs[2].transform.position, ActivePrefabs[1].transform.position, 0.5f);
    }

    public void Result()
    {
        _resultValue = 0;
        for (int i = 0; i < _resultPrefab.transform.childCount-1; i++)
        {
            if (_resultPrefab.transform.GetChild(i).GetComponent<Uchburchak>().Select == true)
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
        for (int i = 0; i < _resultPrefab.transform.childCount-1; i++)
        {
            if (_resultPrefab.transform.GetChild(i).GetComponent<Uchburchak>().Select == true)
            {
                b++;
            }
        }
        if (b>0)
        {
            //if (TestManager.Instance.CheckIsLast())
            //{
            //    FinishEvent.Raise();
            //}
            //else
            //{
                
            //}
            ES3.Save<bool>("Pattern_16_Check", true);
        }
        else
        {
            ES3.Save<bool>("Pattern_16_Check", false);
            
            
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
        ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_16_Check", true);
    }
}
[SerializeField]
public class Data_16
{
    public string title;
    public List<string> problem;
    public List<string> solution;
}

