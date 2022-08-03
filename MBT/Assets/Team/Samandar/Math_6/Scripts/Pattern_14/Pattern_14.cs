
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_14 : MonoBehaviour
{
    public TextAsset jsonText;
    public TEXDraw Problem;
    public Data_14 DataObj;

    void Start()
    {
        var jsonObj = JObject.Parse(jsonText.text);

        DataObj = jsonObj["chapters"][0]["questions"][85]["question"].ToObject<Data_14>();
        string problem1 = DataObj.problem;
        Problem.transform.GetComponent<TEXDraw>().text = problem1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[SerializeField]
public class Data_14
{
    public string title;
    public string problem;

    public List<string> solution = new List<string>();

}