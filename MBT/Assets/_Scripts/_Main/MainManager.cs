using Newtonsoft.Json;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using MBT.Extension;

public class MainManager : MonoBehaviour
{
    public Main MainObj;
    public AssetReference AddressableMainData;
    public GameObject UpdatePanel;
    public GameEvent UpdateEventSO;
    
    private SinfList _mySinfList = new SinfList();    
    private TextAsset _localMainData;  


    // Start is called before the first frame update
    void Awake()
    {        
        AddressableMainData.LoadAssetAsync<TextAsset>().Completed += OnTextJsonLoaded;                
    }

    private void OnTextJsonLoaded(AsyncOperationHandle<TextAsset> obj)
    {
        _localMainData = obj.Result;
        _mySinfList = JsonConvert.DeserializeObject<SinfList>(_localMainData.text);
        EnableButtons();
    }

   

    public void SetClassKey(int index)
    {
        ES3.Save<int>("ClassKey", index);
    }

    void EnableButtons()
    {
        for (int i = 0; i < _mySinfList.sinf.Length; i++)
        {
            if (_mySinfList.sinf[i].Status.Equals("Yes"))
            {
                MainObj.SinfButtonGroup[i].interactable = true;               
                ES3.Save(MainObj.SinfButtonGroup[i].name, 1);
            }
            else
            {
                MainObj.SinfButtonGroup[i].interactable = false;
                ES3.Save(MainObj.SinfButtonGroup[i].name, 0);
            }
        }
        UpdateEventSO.Raise();
    }

    
}


[Serializable]
public class Sinf
{
    public string Class;
    public string Status;
    
}

[Serializable]
public class SinfList
{
    public Sinf[] sinf;
}
