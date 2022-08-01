using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Newtonsoft.Json.Linq;
using System;
using MBT.Extension;

public class ChapterManager : MonoBehaviour
{

    public AssetReference DataBase;
    public GridLayoutGroup GridLayout;
    public ScrollRect ScrollRectObj;
    public GameEvent UpdateEventSO;
    public GameObject UpdatePanel;

    //[HideInInspector]
    public List<Chapter> ChapterPrefabGorup = new List<Chapter>();

    public  GameObject ChapterPrefabObj;
    private TextAsset _localJson;
    private int _numberOfChapter;   
    private DataBaseSO _dataBase;
    IList<ChapterRaw> _chapterGorup;


    private void Awake()
    {
        DataBase.LoadAssetAsync<DataBaseSO>().Completed += DataBaseLoaded;
        
        
    }

    private void DataBaseLoaded(AsyncOperationHandle<DataBaseSO> obj)
    {
        _dataBase = obj.Result;
        if (ES3.KeyExists("InitialTime"))
        {
            if (ES3.Load<bool>("InitialTime"))
            {
                _localJson = Mbt.GetDesiredJSONData(_dataBase);
            }            
        }
        else
        {
            ES3.Save<bool>("InitialTime", true);
            _localJson = Mbt.GetDesiredJSON(_dataBase);
        }
        
        //_jsonDataGroup.LoadAssetAsync<TextAsset>().Completed += JsonLoaded;
        DisableLoadingBar();
        ReadJSON();
    }

    void JsonLoaded(AsyncOperationHandle<TextAsset> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            _localJson = obj.Result;
            ReadJSON();
        }

    }



    void DisableLoadingBar()
    {
        if (ES3.KeyExists("IsInitialLoad"))
        {
            if (ES3.Load<bool>("IsInitialLoad"))
            {
                UpdatePanel.SetActive(false);
            }
        }
            
    }

   



  

 

    void ReadJSON()
    {
        var jo = JObject.Parse(_localJson.text);
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

   

    void CreateChapters()
    {       
        if(_numberOfChapter > 0) 
        {
            for (int i = 0; i < _numberOfChapter; i++)
            {
                GameObject obj = Instantiate(ChapterPrefabObj);
                obj.transform.SetParent(GridLayout.transform);
                obj.transform.localScale = Vector3.one;
                ChapterPrefabGorup.Add(obj.GetComponent<Chapter>());
            }
            GridLayout.gameObject.SetActive(false);
            StartCoroutine(DisplayChapters());
        }
       
    }

    IEnumerator DisplayChapters()
    {
        ES3.Save("IsInitialLoad", true);
        yield return new WaitForSeconds(0.1f);
        GridLayout.gameObject.SetActive(true);
        int k = 0;
        foreach (ChapterRaw item in _chapterGorup)
        {
            ChapterPrefabGorup[k].chapterRaw.name = item.name;
            ChapterPrefabGorup[k].chapterRaw.number = item.number;           
            k++;
        }
        foreach (Chapter item in ChapterPrefabGorup)
        { 
            item.UpdateInfo(JObject.Parse(_localJson.text));            
        }
        UpdateEventSO.Raise();
    }

}



