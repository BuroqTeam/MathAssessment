using MBT.Extension;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MainManager : MonoBehaviour
{
    public Main MainObj;
    public AssetReference AddressableDateAlgebra;
    public AssetReference AddressableDateGeometry;
    public AssetReference AddressableMainData;
   
    
    private SinfList _mySinfList = new SinfList();    
    private TextAsset _localMainData;


    //F++
    public DataBaseSO[] group;
    //private TextAsset _curentJson;
    //private DataBaseSO _jsonCollectionSO;
    public GameObject NoDataPanel;
    //F++

    // Start is called before the first frame update
    void Awake()
    {
        //if (ES3.Load<string>("Subject").Equals("Algebra"))
        //    AddressableMainData = AddressableDateAlgebra;
        //else
        //    AddressableMainData = AddressableDateGeometry;
        //AddressableMainData.LoadAssetAsync<TextAsset>().Completed += OnTextJsonLoaded;

        CheckSubject();
    }

    private void OnTextJsonLoaded(AsyncOperationHandle<TextAsset> obj)
    {
        _localMainData = obj.Result;
        _mySinfList = JsonConvert.DeserializeObject<SinfList>(_localMainData.text);
        EnableButtons();
    }

    

    public void SetClassKey(int index)  // Sinf raqamini saqlaydi.
    {
        ES3.Save<int>("ClassKey", index);
        //CheckJsonFile();//F++
        MainObj.UnEnableButtons(false);
        GetComponent<SceneManager>().LoadLocalScene();
    }


    void EnableButtons()
    {
        for (int i = 0; i < _mySinfList.sinf.Length; i++)
        {           
            if (_mySinfList.sinf[i].Status.Equals("Yes"))
            {
                MainObj.SinfButtonGroup[i].interactable = true;                    
                ES3.Save<int>(MainObj.SinfButtonGroup[i].name, 1);
            }
            else
            {
                MainObj.SinfButtonGroup[i].interactable = false;
                ES3.Save<int>(MainObj.SinfButtonGroup[i].name, 0);
            }

            if (_mySinfList.sinf[i].Visibility.Equals("Yes"))
            {
                MainObj.SinfButtonGroup[i].gameObject.SetActive(true);
                ES3.Save<bool>(MainObj.SinfButtonGroup[i].name + "Visibility", true);
            }
            else
            {
                MainObj.SinfButtonGroup[i].gameObject.SetActive(false);
                ES3.Save<bool>(MainObj.SinfButtonGroup[i].name + "Visibility", false);
            }
            ES3.Save<bool>("InitialSceneLoad1", true);
        }
       
    }


    //F++
    public TextAsset MatematikaText;
    public TextAsset AlgebraText;
    public TextAsset GeometriyaText;
    public TextAsset CurrentText;


    void CheckSubject() //F++
    {
        if (ES3.Load<string>("Subject").Equals("Matematika"))        
            CurrentText = MatematikaText;        
        else if (ES3.Load<string>("Subject").Equals("Algebra"))        
            CurrentText = AlgebraText;        
        else if (ES3.Load<string>("Subject").Equals("Geometriya"))        
            CurrentText = GeometriyaText;
                

        _mySinfList = JsonConvert.DeserializeObject<SinfList>(CurrentText.text);
        EnableButtons();
    }
    
    //void CheckJsonFile()    //F++
    //{
    //    if (ES3.Load<string>("Subject").Equals("Algebra"))        
    //        _jsonCollectionSO = group[0];        
    //    else        
    //        _jsonCollectionSO = group[1];        

    //    _curentJson = Mbt.GetDesiredJSONData(_jsonCollectionSO);
    //    _jsonCollectionSO.DataBase.Clear();
                        
    //    if (_curentJson.text.Length != 0)
    //    {
    //        MainObj.UnEnableButtons(false);     //F++
    //        GetComponent<SceneManager>().LoadLocalScene();
    //    }
    //    else
    //    {
    //        NoDataPanel.SetActive(true);
    //    }
    //}


}


[Serializable]
public class Sinf
{
    public string Class;
    public string Status;
    public string Visibility;


}

[Serializable]
public class SinfList
{
    public Sinf[] sinf;
}
