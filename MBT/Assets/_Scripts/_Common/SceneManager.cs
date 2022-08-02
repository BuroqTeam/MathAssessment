using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour
{
    public AssetReference Scene;


   

    public void LoadLocalScene()
    {
        
        Addressables.LoadSceneAsync(Scene, LoadSceneMode.Single).Completed += SceneLoaded;
    }


    public void LoadMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
    private void SceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {

    }
}
