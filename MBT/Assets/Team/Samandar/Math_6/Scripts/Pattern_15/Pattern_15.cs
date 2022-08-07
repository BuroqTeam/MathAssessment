using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_15 : MonoBehaviour
{
    private TextAsset _jsonText;
    public GameObject Problem;
    public Data_15 DataObj;
    public GameObject Solution;
    public GameObject ConsiderationsPrefabs;
    public List<Button> buttonGroup = new List<Button>();
    public ColorCollectionSO colorCollection;


    private void Awake()
    {

    }


    private void OnEnable()
    {
        _jsonText = GetComponent<Pattern>().Json;

        if (_jsonText != null)
        {
            Debug.Log(_jsonText.text);
        }
        else
        {
            Debug.Log("Not Found Data");
        }

        //_jsonText = Mbt.GetDesiredData(_jsCollection);

        ReadFromJson();

        //DisplayQuestion(DataObj.title);

        StartMetod();
    }
    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "key");
        DataObj = jo.ToObject<Data_15>();
    }

    void StartMetod()
    {
        List<string> problem1 = DataObj.problem;
        Problem.transform.GetChild(0).GetComponent<TEXDraw>().text = problem1[0];
        PrefabsInstantiate();

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
    public List<string> problem = new List<string>();
    public List<string> solution = new List<string>();

}