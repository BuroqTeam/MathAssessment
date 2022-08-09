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
    public GameObject ButtonPrefabs;
    private void Awake()
    {
        Mbt.SaveJsonPath("Pattern_12", 3, 77);

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
            obj.transform.GetChild(1).GetComponent<TEXDraw>().text = AlphabetList[i].ToString();
            //ABCD.Add(obj);
        }
    }

    // Update is called once per frame
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
