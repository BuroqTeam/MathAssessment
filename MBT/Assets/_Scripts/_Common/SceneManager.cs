using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour
{
    public AssetReference Scene;
    public AssetReference CurrentScene;


    //F++
    public GameObject Notification;
    //public UnityEvent ButtonEnableFalse;    
    //public GameEvent LoadingEvent;

    bool m_ReadyToLoad = true;
    private AsyncOperationHandle<SceneInstance> loadHandle;
    SceneInstance m_LoadedScene;
    //F++


    //private void Start()
    //{        
    //    // 100 % bo'lsa
    //    //LoadingEvent.Raise();
    //}

    public void LoadLocalScene()
    {
        //if (Scene.SubObjectName == "Test")
        //{
        //    Logging.Log("")
        //}

        //Loading.SetActive(true);

        StartCoroutine(CheckInternetConnection(isConnected =>
        {
            if (isConnected || PlayerPrefs.GetInt("Initial" + Scene.SubObjectName) > 0)
            {
                if (m_ReadyToLoad)
                {
                    //Logging.Log("Load new Scene");
                    PlayerPrefs.SetInt("Initial" + Scene.SubObjectName.ToString(), 1);
                    loadHandle = Addressables.LoadSceneAsync(Scene, LoadSceneMode.Single, true, 100);
                    loadHandle.Completed += SceneLoadComplete;
                }
                else
                {
                    Addressables.UnloadSceneAsync(m_LoadedScene).Completed += OnSceneUnloaded;
                }
            }
            else
            {
                Notification.SetActive(true);
            }
        }));        

        //Addressables.LoadSceneAsync(Scene, LoadSceneMode.Single).Completed += SceneLoaded;
    }

    public void LoadCurrentScene()
    {
        Addressables.LoadSceneAsync(CurrentScene, LoadSceneMode.Single).Completed += SceneLoaded;
    }


    public void LoadMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void LoadCustonScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
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


    // Loading va Notificationni ishlashi uchun qo'shilgan metodlar.

    void SceneLoadComplete(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj)
    {

        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            m_ReadyToLoad = false;
            m_LoadedScene = obj.Result;
        }
    }


    void OnSceneUnloaded(AsyncOperationHandle<SceneInstance> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            m_ReadyToLoad = true;
            m_LoadedScene = new SceneInstance();
        }
    }


    IEnumerator CheckInternetConnection(Action<bool> action)
    {
        UnityWebRequest request = new UnityWebRequest("http://google.com");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            action(false);
        }
        else
        {
            action(true);
        }
    }

}
