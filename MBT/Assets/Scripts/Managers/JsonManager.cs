using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class JsonManager : MonoBehaviour
{
    public AssetReference MainSceneData;
    public SinfList mySinfList = new SinfList();
    
    private TextAsset _MainSceneJSON;  


    // Start is called before the first frame update
    void Awake()
    {
        MainSceneData.LoadAssetAsync<TextAsset>().Completed += OnTextJsonLoaded;       
    }

    private void OnTextJsonLoaded(AsyncOperationHandle<TextAsset> obj)
    {
        _MainSceneJSON = obj.Result;


        mySinfList = JsonUtility.FromJson<SinfList>(_MainSceneJSON.text);

    }

   

    
}

[Serializable]
public class Sinf
{
    public string ClassNumber;
    public string Status;
    
}

[Serializable]
public class SinfList
{
    public Sinf[] sinf;
}
