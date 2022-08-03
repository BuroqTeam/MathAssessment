using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using MBT.Extension;
using System;

public class Pattern_2 : TestManager
{    
    
    public AssetReference ButtonAddressable;
    public DataBaseSO dataBase;

    private AssetReference _jsonData;
    public  GameObject _button;
    public TextAsset _currentJsonText;
    Data_2 Pattern_2Obj = new Data_2();

    private void Awake()
    {
        Mbt.SaveJsonPath("key", 0, 10);


        ES3.Save<string>("LanguageKey", "Class_6_Uzb");


        ES3.Save<int>("ClassKey", 6);

        //_jsonData = Mbt.GetDesiredJSON(dataBase);      
        _jsonData.LoadAssetAsync<TextAsset>().Completed += DataBaseLoaded;
    }

   

    private void DataBaseLoaded(AsyncOperationHandle<TextAsset> obj)
    {
        _currentJsonText = obj.Result;
        ButtonAddressable.LoadAssetAsync<GameObject>().Completed += ButtonAddressableObjLoaded;
    }

   

    private void ButtonAddressableObjLoaded(AsyncOperationHandle<GameObject> obj)
    {
        _button = obj.Result;
        ReadFromJson();
    }

   
    private void OnEnable()
    {
        DisplayQuestion(Pattern_2Obj.title);
    }


    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr); // null        
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "key");
        Pattern_2Obj = jo.ToObject<Data_2>();
        CreatePrefabs();
    }

    public void CreatePrefabs()
    {
        if (Pattern_2Obj.options.Count % 4 == 0)
        {
            int x = -100, y = 100, w=0;
            for (int i = 0; i < Pattern_2Obj.options.Count; i++)
            {
                if (i< Pattern_2Obj.options.Count/2)
                {
                    GameObject button = Instantiate(_button, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x - ((Pattern_2Obj.options.Count / 4 - 1)-i) * 200, y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                }
                else
                {
                    GameObject button = Instantiate(_button, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x - ((Pattern_2Obj.options.Count / 4 - 1) - w) * 200, -y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                    w++;
                }
            }
        }
        else
        {
            int x = 0, y = 100, q = 0;
            for (int i = 0; i < Pattern_2Obj.options.Count; i++)
            {
                if (i < Pattern_2Obj.options.Count / 2)
                {
                    GameObject button = Instantiate(_button, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3((-(Pattern_2Obj.options.Count / 4) + i) * 200, y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                }
                else
                {
                    GameObject button = Instantiate(_button, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3((-(Pattern_2Obj.options.Count / 4) + q) * 200, -y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                    q++;
                }
            }
        }
        // gameObject.SetActive(false);
    }
}

[SerializeField]
public class Data_2
{
    public string title;
    public List<string> options;
}


