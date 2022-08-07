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
    public DataBaseSO DataBases;
    public TextAsset jsonText;
    public Data_11 DataObj;
    public List<GameObject> NumberInstantiate;
    private List<string> AlphabetList;
    private void Awake()
    {
        Mbt.SaveJsonPath("key", 1, 66);

        ES3.Save<string>("LanguageKey", "Uzb");

        ES3.Save<int>("ClassKey", 6);

        jsonText = Mbt.GetDesiredJSONData(DataBases);

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
        for (int i = 0; i < options1.Count; i++)
        {
            var likeName = DataObj.options[i];

            string mainString2 = LeftList[i].transform.GetChild(0).GetComponent<NumBoxP_3>().CurrentNumber;
            //Ansver.Add(mainString2);

            if (likeName.Contains('['))
            {
                likeName = likeName.Replace("[a]", "");
                likeName = likeName.Replace("[b]", "");
                likeName = likeName.Replace("[c]", "");
                likeName = likeName.Replace("[d]", "");
                likeName = likeName.Replace("[e]", "");
                likeName = likeName.Replace("[f]", "");
            }
            DataObj.options[i] = likeName;


            GameObject Right = Instantiate(PushableRectangle, PanelRight.transform);
            RightList.Add(Right);
            PanelRight.transform.GetChild(i).transform.GetChild(0).GetComponent<TEXDraw>().text = options1[i].ToString();
            GameObject Left = Instantiate(PushableShadow, PanelLeft.transform);
            LeftList.Add(Left);
        }
        for (int i = 0; i < RightList.Count; i++)
        {
            RightList[i].GetComponent<DegnDropPattern_11>().Pattern11 = this;
            RightList[i].GetComponent<DegnDropPattern_11>().Positions = LeftList;
        }
    }

    public void Check()
    {

    }
}

[SerializeField]
public class Data_11
{
    public string title;
    public List<string> options = new List<string>();
}