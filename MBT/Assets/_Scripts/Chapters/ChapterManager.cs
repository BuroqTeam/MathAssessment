using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ChapterManager : MonoBehaviour
{

    public DataBaseSO JsonCollection;

    public GridLayoutGroup GridLayout;
    public ScrollRect ScrollRectObj;
    
   

    //[HideInInspector]
    public List<Chapter> ChapterGorup = new List<Chapter>();

    public  GameObject ChapterPrefab;
    private  TextAsset _curentJson;
    private int _numberOfChapter;   
   
    IList<ChapterRaw> _chapterGorup;


    private void Awake()
    {
        _curentJson = GetDesiredJSONData(JsonCollection);
        JsonCollection.DataBase.Clear();
        ReadJSON();
    }

  
    void ReadJSON()
    {
        var jo = JObject.Parse(_curentJson.text);
        JArray chapters = (JArray)jo["chapters"];
        _numberOfChapter = chapters.Count;
        _chapterGorup = chapters.ToObject<IList<ChapterRaw>>();
        CreateChapters();
        SetScrollRect();
    }


    void SetScrollRect()
    {
        if (_numberOfChapter > 10)
        {
            ScrollRectObj.enabled = true;
            Color col = Color.gray;
            col.a = 1;
            ScrollRectObj.GetComponent<Image>().color = col;
        }
        else
        {
            ScrollRectObj.enabled = false;
            Color col = Color.white;
            col.a = 0.1f;
            ScrollRectObj.GetComponent<Image>().color = col;
        }
    }

    TextAsset GetDesiredJSONData(DataBaseSO dataBase)
    {
        TextAsset textAsset = new TextAsset();
        dataBase.CreateDict();
        string currentLanguage = ES3.Load<string>("LanguageKey");
        int currentClass = ES3.Load<int>("ClassKey");        
        Dictionary<int, List<TextAsset>> JsonDictionary = new Dictionary<int, List<TextAsset>>(dataBase.DataBase);        
        List<TextAsset> list = new List<TextAsset>();
        if (JsonDictionary.TryGetValue(currentClass, out list))
        {
            foreach (TextAsset txtAsset in list)
            {
                if (txtAsset.name.Equals(currentLanguage))
                {
                    textAsset = txtAsset;
                }
            }
        }
        return textAsset;
    }


    void CreateChapters()
    {       
        if(_numberOfChapter > 0) 
        {
            for (int i = 0; i < _numberOfChapter; i++)
            {
                GameObject obj = Instantiate(ChapterPrefab);
                obj.transform.SetParent(GridLayout.transform);
                obj.transform.localScale = Vector3.one;
                ChapterGorup.Add(obj.GetComponent<Chapter>());
            }
            GridLayout.gameObject.SetActive(false);
            StartCoroutine(DisplayChapters());
        }
       
    }

    IEnumerator DisplayChapters()
    {   
        yield return new WaitForSeconds(0.1f);
        GridLayout.gameObject.SetActive(true);
        int k = 0;
        foreach (ChapterRaw item in _chapterGorup)
        {
            ChapterGorup[k].chapterRaw.name = item.name;
            ChapterGorup[k].chapterRaw.number = item.number;           
            k++;
        }
        foreach (Chapter item in ChapterGorup)
        { 
            item.UpdateInfo(JObject.Parse(_curentJson.text));            
        }
        
    }

}



