using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChapterManager : MonoBehaviour
{
    public DataBaseSO [] group;
    public GridLayoutGroup GridLayout;
    public ScrollRect ScrollRectObj;
    [HideInInspector]
    public int NumberOfChapter;
    public List<Chapter> ChapterGorup = new();
    public  GameObject ChapterPrefab;

    private  TextAsset _curentJson;    
    private DataBaseSO _jsonCollectionSO;

    IList<ChapterRaw> _chapterGorup;


    private void Awake()
    {
        if (ES3.Load<string>("Subject").Equals("Algebra"))
        {
            _jsonCollectionSO = group[0];
        }
        else
        {
            _jsonCollectionSO = group[1];
        }       
        _curentJson = Mbt.GetDesiredJSONData(_jsonCollectionSO);       
        _jsonCollectionSO.DataBase.Clear();
        ReadJSON();
    }

    void ReadJSON()
    {
        var jo = JObject.Parse(_curentJson.text);
        JArray chapters = (JArray)jo["chapters"];
        NumberOfChapter = chapters.Count;
        _chapterGorup = chapters.ToObject<IList<ChapterRaw>>();        
        CreateChapters();
        SetScrollRect();
    }
    void SetScrollRect()
    {
        if (NumberOfChapter > 10)
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
    void CreateChapters()
    {       
        
        if(NumberOfChapter > 0) 
        {
            for (int i = 0; i < NumberOfChapter; i++)
            {
                GameObject obj = Instantiate(ChapterPrefab);
                obj.transform.SetParent(GridLayout.transform);
                obj.transform.localScale = Vector3.one;
                obj.GetComponent<RectTransform>().DOAnchorPos3DZ(0, 0);
                ChapterGorup.Add(obj.GetComponent<Chapter>());
            }
            GridLayout.gameObject.SetActive(false);
            StartCoroutine(DisplayChapters());
        }       
    }

    IEnumerator DisplayChapters()
    {   
        
        GridLayout.gameObject.SetActive(true);
        int k = 0;
        foreach (ChapterRaw item in _chapterGorup)
        {
            ChapterGorup[k].chapterRaw.name = item.name;
            ChapterGorup[k].chapterRaw.number = item.number;
            ChapterGorup[k].chapterRaw.description = item.description;
           
            k++;
        }
        foreach (Chapter item in ChapterGorup)
        { 
            item.UpdateInfo(JObject.Parse(_curentJson.text));            
        }
        GetComponent<ProgressManager>().CheckSaveCondition();
        yield return new WaitForSeconds(0.1f);
    }


    public int SetProgressValues()
    {
        string sample = ChapterGorup[0].questionGroup[0].pattern;
        int k = 0;
        for (int i = 0; i < ChapterGorup[0].questionGroup.Count; i++)
        {
            if (sample.Equals(ChapterGorup[0].questionGroup[i].pattern))
            {
                k++;
            }
        }
        return k;
    }

}



