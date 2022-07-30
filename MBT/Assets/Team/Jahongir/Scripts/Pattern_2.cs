using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Extensions = Extension.Extensions;

public class Pattern_2 : TestManager
{    
    
    public AssetReference ButtonAddressable;
    
    private GameObject _button;
    private TextAsset _currentJsonText;
    Data_2 Pattern_2Obj = new Data_2();


    private void Start()
    {

        ButtonAddressable.LoadAssetAsync<GameObject>().Completed += ButtonAddressableObjLoaded;
        //ReadFromJson();
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
        JObject jo = Extensions.LoadJsonPath(jsonObj); 
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


