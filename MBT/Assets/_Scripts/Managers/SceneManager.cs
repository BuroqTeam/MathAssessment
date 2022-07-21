using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public AssetReference SceneToLoad;
    

    public void LoadAddressableScene()
    {
        Addressables.LoadSceneAsync(SceneToLoad, LoadSceneMode.Single).Completed += OnSceneLoaded;
    }

    public void LoadLocalScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    

    void OnSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        
    }

   

   

}
