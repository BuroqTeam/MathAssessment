using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_15 : GeneralTest
{
    public GameEvent ActiveNext;
    public GameEvent DeactiveNext;
    private TextAsset _jsonText;
    public GameObject Problem;
    public Data_15 DataObj;
    public GameObject Solution;
    public GameObject ConsiderationsPrefabs;
    public List<Button> buttonGroup = new();
    public ColorCollectionSO colorCollection;
    public bool _istrue = true;
    public AnswerPattern_15 AnswerPattern_15;
    public bool _pattenBool;
    public bool _click;

    private void OnEnable()
    {
        if (_istrue)
        {
            _istrue = false;
            _jsonText = GetComponent<Pattern>().Json;
            ReadFromJson();
            StartMetod();
            PrefabsInstantiate();
        }
        
        //_jsonText = Mbt.GetDesiredData(_jsCollection);

        DisplayQuestion(DataObj.title);
        
    }
    public void Check()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        AnswerPattern_15._PattenBool = _pattenBool;
        if (_pattenBool == true && _click == true)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            Debug.Log("Corrent");
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            Debug.Log("Wrong");
        }
        ActivateNextQestion();
    }
    public void Active()
    {
        if (_click)
        {
            ActiveNext.Raise();
        }
    }
    void ActivateNextQestion()
    {
        int index = TestManager.Instance.ActivePatterns.FindIndex(o => o == gameObject);
        index++;
        TestManager.Instance.ActivePatterns[index].SetActive(true);
        gameObject.SetActive(false);
    }
    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_15");
        DataObj = jo.ToObject<Data_15>();
    }

    void StartMetod()
    {
        List<string> problem1 = DataObj.problem;
        Problem.transform.GetChild(0).GetComponent<TEXDraw>().text = problem1[0];
        
    }
    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }


    void PrefabsInstantiate()
    {
        List<string> solution1 = DataObj.solution;
        for (int i = 0; i < solution1.Count; i++)
        {
            
            GameObject obj = Instantiate(ConsiderationsPrefabs, Solution.transform);
            buttonGroup.Add(obj.GetComponent<Button>());
            var likeName = DataObj.solution[i];
            Solution.transform.GetChild(i).transform.GetComponent<AnswerPattern_15>().Pattern15 = this;

            if (likeName.Contains('*'))
            {
                Solution.transform.GetChild(i).transform.GetComponent<AnswerPattern_15>()._PattenBool = true;
                likeName = likeName.Replace("[*]", "");
            }
            DataObj.solution[i] = likeName;


            Solution.transform.GetChild(i).transform.GetChild(0).transform.GetComponent<TEXDraw>().text = solution1[i];
            if (Solution.transform.childCount == 2)
            {
                Solution.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = colorCollection.Green;
                Solution.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = colorCollection.Red;
            }
            else if (Solution.transform.childCount == 3)
            {
                Solution.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = colorCollection.Green;
                Solution.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = colorCollection.Green;
                Solution.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = colorCollection.Green;
            }
        }
    }
}

[SerializeField]
public class Data_15
{
    public string title;
    public List<string> problem = new();
    public List<string> solution = new();

}