
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_14 : MonoBehaviour
{
    public DataBaseSO DataBase;
    public TextAsset jsonText;
    public GameObject Problem;
    public Data_14 DataObj;
    public GameObject Solution;
    public GameObject ConsiderationsPrefabs;
    public List<Button> buttonGroup = new List<Button>();



    private void Awake()
    {
        Mbt.SaveJsonPath(9, 96);

        ES3.Save<string>("LanguageKey", "Uzb");

        ES3.Save<int>("ClassKey", 6);

        jsonText = Mbt.GetDesiredJSONData(DataBase);

        ReadFromJson();
    }


    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj);
        DataObj = jo.ToObject<Data_14>();
    }

    void Start()
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
            Solution.transform.GetChild(i).transform.GetComponent<AnswerPattern_14>().Pattern14 = this;

            if (likeName.Contains('*'))
            {
                Solution.transform.GetChild(i).transform.GetComponent<AnswerPattern_14>()._PattenBool = true;
                likeName = likeName.Replace("[*]", "");
            }
            DataObj.solution[i] = likeName;

            
            Solution.transform.GetChild(i).transform.GetChild(0).transform.GetComponent<TEXDraw>().text = solution1[i];
            if (Solution.transform.childCount == 2)
            {
                Solution.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = new Color(0, 0.6941177f, 0.07058824f, 1);
                Solution.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = new Color(1, 0, 0, 1);
            }
            else if (Solution.transform.childCount == 3)
            {
                Solution.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = new Color(0, 0.6941177f, 0.07058824f, 1);
                Solution.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = new Color(0, 0.6941177f, 0.07058824f, 1);
                Solution.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = new Color(0, 0.6941177f, 0.07058824f, 1);
            }
        }
    }
}

[SerializeField]
public class Data_14
{
    public string title;
    public List<string> problem = new List<string>();
    public List<string> solution = new List<string>();

}