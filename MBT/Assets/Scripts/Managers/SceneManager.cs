using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class SceneManager : MonoBehaviour
{

    public string SceneAdressToLoad;
    


    // Start is called before the first frame update
    void Awake()
    {
        if (SceneAdressToLoad.Equals("Main"))
        {
            Addressables.LoadSceneAsync(SceneAdressToLoad, UnityEngine.SceneManagement.LoadSceneMode.Single).Completed += OnSceneLoaded;
        }        
    }

    public void LoadAddressableScene()
    {
        Addressables.LoadSceneAsync(SceneAdressToLoad, UnityEngine.SceneManagement.LoadSceneMode.Single).Completed += OnSceneLoaded;
    }


    void OnSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        
    }

   

   

}
