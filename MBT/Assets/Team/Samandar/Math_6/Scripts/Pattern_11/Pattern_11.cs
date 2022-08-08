using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_11 : MonoBehaviour
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
    public List<string> Answer;
    public List<char> AlphabetList = new();
    private void Awake()
    {
        Mbt.SaveJsonPath("Pattern_11", 1, 60);

        ES3.Save<string>("LanguageKey", "Uzb");

        ES3.Save<int>("ClassKey", 6);

        jsonText = Mbt.GetDesiredJSONData(DataBases);

        ReadFromJson();
    }
    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_11");
        DataObj = jo.ToObject<Data_11>();        
    }

    void Start()
    {
        ObjInstantiate();
    }
    void ObjInstantiate()
    {
        for (char ci = 'a'; ci <= 'z'; ++ci)
        {
            AlphabetList.Add(ci);
        }

        List<string> str = DataObj.options;
        for (int i = 0; i < str.Count; i++)
        {
            string strAlphabet = "[" + AlphabetList[i] + "]";
            for (int j = 0; j < str.Count; j++)
            {
                var likeName = DataObj.options[j];
                if (likeName.Contains(strAlphabet))
                {
                    Correct.Add(DataObj.options[j]);
                    Debug.Log(AlphabetList[i] + " " + DataObj.options[j]);
                    break;
                }
            }

        }

        str = str.ShuffleList();
        DataObj.options = str;
        
        for (int i = 0; i < str.Count; i++)
        {
            
            var likeName = DataObj.options[i];
                 

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


            GameObject right = Instantiate(PushableRectangle, PanelRight.transform);
            RightList.Add(right);
            PanelRight.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = str[i].ToString();
            GameObject left = Instantiate(PushableShadow, PanelLeft.transform);           
            LeftList.Add(left);
           
        }
        for (int i = 0; i < RightList.Count; i++)
        {
            RightList[i].transform.GetChild(0).GetComponent<PushableRectangle>().Pattern11 = this;
            RightList[i].transform.GetChild(0).GetComponent<PushableRectangle>().Positions = LeftList;
        }
        Check();
    }
    public void Checking()
    {
        List<string> str = DataObj.options;
        Answer.Clear();
        for (int i = 0; i < str.Count; i++)
        {
            string mainString = LeftList[i].GetComponent<PushableShadow>().CurrentNumber;
            Answer.Add(mainString);
        }
    }
    public List<string> Correct;
    public void Check()
    {
      

        
    }
}

[SerializeField]
public class Data_11
{
    public string title;
    public List<string> options = new();
}