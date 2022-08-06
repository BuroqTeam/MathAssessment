using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_11 : TestManager
{
    public GameObject PushableShadow;
    public GameObject PushableRectangle;
    public GameObject PanelLeft;
    public GameObject PanelRight;
    public List<GameObject> LeftList;
    public List<GameObject> RightList;
    public DataBaseSO DataBase;
    public TextAsset jsonText;
    public Data_11 DataObj;
    private void Awake()
    {
        Mbt.SaveJsonPath("key", 1, 66);

        ES3.Save<string>("LanguageKey", "Uzb");

        ES3.Save<int>("ClassKey", 6);

        jsonText = Mbt.GetDesiredJSONData(DataBase);

        ReadFromJson();
    }
    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "key");
        DataObj = jo.ToObject<Data_11>();
        
    }

    void Start()
    {
        ObjInstantiate();
    }


    void ObjInstantiate()
    {
        List<string> options1 = DataObj.options;
        Debug.Log(options1.Count);
        for (int i = 0; i < options1.Count; i++)
        {
            GameObject Right = Instantiate(PushableRectangle, PanelRight.transform);
            RightList.Add(Right);
            PanelRight.transform.GetChild(i).transform.GetChild(0).GetComponent<TEXDraw>().text = options1[i].ToString();
            GameObject Left = Instantiate(PushableShadow, PanelLeft.transform);
            LeftList.Add(Right);
        }
    }
}

[SerializeField]
public class Data_11
{
    public string title;
    public List<string> options = new List<string>();
}