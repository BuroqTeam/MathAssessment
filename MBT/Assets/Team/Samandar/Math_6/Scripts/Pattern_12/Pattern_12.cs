using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_12 : MonoBehaviour
{
    public TextAsset _jsonText;
    public Data_12 DataObj;
    public GameObject Answers;
    public List<char> AlphabetList = new();
    public List<GameObject> ABCD;
    public GameObject ButtonPrefabs;
    private void Awake()
    {
        Mbt.SaveJsonPath("Pattern_12", 3, 70);

        ES3.Save<string>("LanguageKey", "Uzb");

        ES3.Save<int>("ClassKey", 6);

        //jsonText = Mbt.GetDesiredJSONData(DataBases);

        ReadFromJson();
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_12");
        DataObj = jo.ToObject<Data_12>();
    }

    void Start()
    {
        for (char ci = 'A'; ci <= 'Z'; ++ci)
        {
            AlphabetList.Add(ci);
        }
        List<string> str = DataObj.options;
        for (int i = 0; i < str.Count; i++)
        {
            GameObject obj = Instantiate(ButtonPrefabs, Answers.transform);
            obj.transform.GetChild(0).GetComponent<TEXDraw>().text = AlphabetList[i].ToString();
            //obj.transform.GetChild(1).GetComponent<TEXDraw>().text = str[i].ToString();
            ABCD.Add(obj);
        }

        //List<string> str = DataObj.options;
        str = str.ShuffleList();
        DataObj.options = str;

        for (int i = 0; i < ABCD.Count; i++)
        {
            var likeName = DataObj.options[i];
            ABCD[i].GetComponent<ButtonAnswer>().Pattern12 = this;

            if (likeName.Contains('*'))
            {
                ABCD[i].GetComponent<ButtonAnswer>()._pattern = true;
                likeName = likeName.Replace("[*]", "");
            }
            ABCD[i].GetComponent<ButtonAnswer>().WriteCurrentAnswer(likeName);
        }
    }

    
    void Update()
    {
        
    }
  
}

[SerializeField]
public class Data_12
{
    public string title;
    public List<string> options;
}
