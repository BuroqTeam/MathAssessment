using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class Pattern_3 : TestManager
{
    public TextAsset jsonText;
    public string sampleQuestion;
    public List<TEXDraw> NumbersText;
    public List<GameObject> Numbers;
    public List<GameObject> NumbersParent;
    public GameObject NumberPrefabs;
    public GameObject NumberAreaPrefabs;
    public List<GameObject> NumberArea;
    private GameObject MainParent;
    //public GameObject QuestionObj;
    public Data_3 DataObj;
    public TEXDraw NumberActions;
    public List<GameObject> NumberInstantiate;
    public AssetReference PrefabPattern;
    public AssetReference PrefabPattern1;
    public List<GameObject> CheckList2;
    public List<GameObject> CheckList4;
    public List<GameObject> CheckList6;

    void Start()
    {

        PrefabPattern.LoadAssetAsync<GameObject>().Completed += PrefabPatternObjLoaded;
        PrefabPattern1.LoadAssetAsync<GameObject>().Completed += PrefabPattern1ObjLoaded;
              

        //MainParent = gameObject.transform.parent.transform.parent.gameObject;
        //QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;
        var jsonObj = JObject.Parse(jsonText.text);
               
       
        DataObj = jsonObj["chapters"][0]["questions"][24]["question"].ToObject<Data_3>();
        List<string> problem1 = DataObj.problem;

        

        List<string> solution1 = DataObj.solution[0];
        //string _problem = objaa.problem[0];

        for (int i = 0; i < DataObj.solution.Count; i++)
        {

        }
        for (int i = 0; i < problem1.Count; i++)
        {
            NumbersParent[i].transform.parent.gameObject.transform.GetComponent<HorizontalLayoutGroup>().enabled = false;
            NumbersParent[i].SetActive(true);
            GameObject Obj1 = Instantiate(NumberPrefabs, NumbersParent[i].transform);
            Numbers.Add(Obj1);
        }


        for (int i = 0; i < solution1.Count - 1; i++)
        {
            GameObject obj = Instantiate(NumberAreaPrefabs, NumberArea[i].transform);
            if (solution1.Count - 1 == 2)
            {
                NumberActions.transform.GetComponent<TEXDraw>().text = solution1[1].ToString();
            }
            if (solution1.Count - 1 == 4)
            {
                NumberActions.transform.GetComponent<TEXDraw>().text = solution1[2].ToString();
            }
            if (solution1.Count - 1 ==  6)
            {
                NumberActions.transform.GetComponent<TEXDraw>().text = solution1[3].ToString();
            }
            NumberInstantiate.Add(obj);
        }
        for (int i = 0; i < Numbers.Count; i++)
        {
            Numbers[i].GetComponent<DegnDropPattern_3>().Pattern3 = this;
            Numbers[i].GetComponent<DegnDropPattern_3>().Positions = NumberInstantiate;
        }

        for (int i = 0; i < problem1.Count; i++)
        {
            NumbersParent[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = problem1[i].ToString();
        }

        CheckingAnswer();
        RemakeJsonSolution();
        
    }

    void PrefabPatternObjLoaded(AsyncOperationHandle<GameObject> obj)
    {
        NumberPrefabs = obj.Result;        
    }

    void PrefabPattern1ObjLoaded(AsyncOperationHandle<GameObject> obj)
    {
        NumberAreaPrefabs = obj.Result;
    }

    private void OnEnable()
    {
        DisplayQuestion(sampleQuestion);
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);  

    }

    void objPrefab()
    {
        for (int i = 0; i < NumberArea.Count; i++)
        {
            GameObject obj = Instantiate(NumberAreaPrefabs, NumberArea[i].transform);
        }
        
    }
    public void DisplayQuestion()
    {
        //Questions.text = objaa.title;

    }


    public List<GameObject> MainList = new List<GameObject>();
    public int CorrectAnsNumbers;


    public void CheckingAnswer()
    {
        List<string> solution1 = DataObj.solution[0];
        int javoblarSoni = solution1.Count;
        if (javoblarSoni == 2)
        {
            MainList = CheckList2;
            Debug.Log(2);
        }
        else if (javoblarSoni == 4)
        {
            MainList = CheckList4;
            Debug.Log(4);
        }
        else if (javoblarSoni == 6)
        {
            MainList = CheckList6;
            Debug.Log(6);
        }

        for (int i = 0; i < DataObj.solution.Count; i++)
        {
            CorrectAnsNumbers = 0;
            List<string> newList = DataObj.solution[i];
            for (int j = 0; j < newList.Count; j++)
            {
                if (newList.Count == 3)
                {

                }
                else if (newList.Count == 5)
                {

                }
                else if (newList.Count == 7)
                {

                }
                string mainString = MainList[j].transform.GetChild(0).GetComponent<NumBoxP_3>().CurrentNumber;
                string jsonString = newList[j];

                //if (mainString == jsonString)
                //{
                //    CorrectAnsNumbers++;
                //}
            }
            if (CorrectAnsNumbers == javoblarSoni)
            {
                Debug.Log("Hammasi to'g'ri.");
                break;
            }
        }

    }

    public List<List<string>> newSolution = new List<List<string>>();
    public List<string> SmallList;
    void RemakeJsonSolution()
    {
        newSolution = new List<List<string>>(DataObj.solution);       

        foreach (List<string> list in newSolution)
        {
            var middleValue = list[list.Count / 2];
            list.Remove(middleValue);
        }

        SmallList.Add("3");
        SmallList.Add("8");
        SmallList.Add("4");
        SmallList.Add("9");

        int k = 0;
        foreach (List<string> list in newSolution)
        {
            if (list.SequenceEqual(SmallList))
            {
                Debug.Log("Correct");
            }
            else
            {
                k++;
            }            
        }

        if (k.Equals(newSolution.Count))
        {
            Debug.Log("Wrong");
        }


        //List<string> newList;
        //for (int i = 0; i < DataObj.solution.Count; i++)
        //{
        //    SmallList = new List<string>();
        //    List<string> jsonList = DataObj.solution[i];
        //    for (int j = 0; j < jsonList.Count; j++)
        //    {
        //        string str = jsonList[j];
        //        string str2 = DataObj.solution[i][j];
        //        if (jsonList.Count / 2 == j)
        //        {
        //            //Debug.Log("amal");
        //        }
        //        else
        //        {
        //            SmallList.Add(str);
        //            Debug.Log(str);
        //            //newSolution[i][j] = objaa.solution[i][j];
        //        }

        //    }

        //    newSolution.Add(SmallList);
        //    //SmallList.Clear();
        //}
        //Debug.Log(newSolution.Count + "  " + newSolution[0].Count);
    }

    




}

[SerializeField]
public class Data_3
{
    public string title;    
    public List<string> problem = new List<string>();

    //public Dictionary<int, List<string>> solution = new Dictionary<int, List<string>>();

    public List<List<string>> solution = new List<List<string>>();
     
}

