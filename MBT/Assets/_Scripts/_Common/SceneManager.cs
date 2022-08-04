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

    public void LoadSubjectScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Subject");
    }

    private void SceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {

    }


    public void SelectSubject(string name)
    {
        ES3.Save<string>("Subject", name);
        
    }
}
