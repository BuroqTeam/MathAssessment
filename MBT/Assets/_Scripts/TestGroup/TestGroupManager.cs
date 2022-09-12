using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestGroupManager : MonoBehaviour
{
    public ProgressKeySO ProgressSave;
    public DataBaseSO[] group;
   
    public GridLayoutGroup GridLayout;
    public ScrollRect ScrollRectObj;

    public TMP_Text ChapterName;
    public TMP_Text ChapterDescription;       

    //[HideInInspector]
    public List<TestGroup> TestGroupButtons = new();
    public GameObject TestGroupObj;   
    private TextAsset _curentJson;
    private DataBaseSO _jsonCollectionSO;


    private void Awake()
    {
        if (ES3.Load<string>("Subject").Equals("Algebra"))
        {
            _jsonCollectionSO = group[0];
        }
        else
        {
            _jsonCollectionSO = group[1];
        }
        ChapterName.text = ES3.Load<string>("ChapterName");
        ChapterDescription.text = ES3.Load<string>("ChapterDescription");
        _curentJson = Mbt.GetDesiredJSONData(_jsonCollectionSO);
        _jsonCollectionSO.DataBase.Clear();
        ReadJSON();
        
    }


   
    void ReadJSON()
    {
        var jo = JObject.Parse(_curentJson.text);
        JArray testGroup = (JArray)jo["chapters"];       
        CreateTestGroup();
        SetScrollRect();
    }


    void SetScrollRect()
    {
        if (ES3.Load<int>("NumberOfTestGroup") > 10)
        {
            ScrollRectObj.enabled = true;
            Color col = Color.gray;
            col.a = 1;
            ScrollRectObj.GetComponent<Image>().color = col;
        }
        else
        {
            ScrollRectObj.enabled = false;
            Color col = Color.white;
            col.a = 0.1f;
            ScrollRectObj.GetComponent<Image>().color = col;
        }
    }



    void CreateTestGroup()
    {
        if (ES3.Load<int>("NumberOfTestGroup") > 0)
        {
            for (int i = 0; i < ES3.Load<int>("NumberOfTestGroup"); i++)
            {
                GameObject obj = Instantiate(TestGroupObj);
                obj.transform.SetParent(GridLayout.transform);
                obj.transform.localScale = Vector3.one;                
                obj.transform.GetComponent<SceneManager>().Notification = this.GetComponent<SceneManager>().Notification; //F++
                TestGroupButtons.Add(obj.GetComponent<TestGroup>());
            }
            
            GridLayout.gameObject.SetActive(false);
            StartCoroutine(DisplayTestGroup());
            UpdateProgress();
        }
        else
        {
            Debug.Log("FUCK");
        }
    }



    IEnumerator DisplayTestGroup()
    {        
        GridLayout.gameObject.SetActive(true);
        int k = 1;
        foreach (TestGroup item in TestGroupButtons)
        {
            item.RawTestGroup.number = k.ToString();           
            k++;
        }
        foreach (TestGroup item in TestGroupButtons)
        {
            item.UpdateInfo();
        }
        yield return new WaitForSeconds(0.1f);

    }

    void UpdateProgress()
    {
        if (ES3.KeyExists(ProgressSave.Key + ES3.Load<string>("Subject") + ES3.Load<int>("ClassKey").ToString()))
        {
            int selectedChapter = ES3.Load<int>("Chapter");
            Dictionary<int, List<float>> dict = ES3.Load<Dictionary<int, List<float>>>(ProgressSave.Key + ES3.Load<string>("Subject") + ES3.Load<int>("ClassKey").ToString());
            List<float> list = dict.ElementAt(selectedChapter).Value;
            int k = 0;
            foreach (float testGroupProgress in list)
            {
                
                TestGroupButtons[k].RadialSliderValue = testGroupProgress;
                TestGroupButtons[k].UpdateInfo();
                k++;
            }           
        }
        
    }
}
