using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONRead : MonoBehaviour
{
    public TextAsset jsonText;
    public GameObject Buttons;
    Pattern2Data obj = new Pattern2Data();




    private void Start()
    {
        //string json = File.ReadAllText("")
        //obj = JsonConvert.DeserializeObject<Pattern2Data>(jsonText.text);


        //PlayerStats stats = new PlayerStats();

        //var jo = new JObject(); 
        //jo.Add("PlayerName", "Frank"); 
        //jo.Add("Age", 36); 
        //jo.Add("Stats", JToken.FromObject(stats));

        //var json = jo.ToString();

        var jsonObj = JObject.Parse(jsonText.text);
        JArray list = (JArray)jsonObj["chapters"][0]["questions"][3]["question"]["options"];

        Debug.Log(list.Count);



        //transform.GetChild(1).transform.GetComponent<TEXDraw>().text = likeName;
        //for (int i = 0; i < 12; i++)
        //{
        //    var buttonNumber = jsonObj["chapters"][0]["questions"][3]["question"]["options"][i].Value<string>();
        //    Buttons.transform.GetChild(i).transform.GetComponent<TEXDraw>().text = jsonObj["chapters"][0]["questions"][3]["question"]["options"][i].Value<string>();
        //}

        //Debug.Log(likeName);
    }



}


[SerializeField]
public class PlayerStats
{

}


[SerializeField]
public class Pattern2Data
{
    public string title;
    public string[] options;
}
