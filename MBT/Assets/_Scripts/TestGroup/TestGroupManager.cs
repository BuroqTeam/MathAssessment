using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestGroupManager : MonoBehaviour
{
    public DataBaseSO JsonCollectionSO;
    public GridLayoutGroup GridLayout;
    public ScrollRect ScrollRectObj;

    public TMP_Text ChapterName;
    public TMP_Text ChapterDescription;       

    //[HideInInspector]
    public List<TestGroup> TestGroupButtons = new List<TestGroup>();
    public GameObject TestGroupObj;   
    private TextAsset _curentJson;
    


    private void Awake()
    {
        ChapterName.text = ES3.Load<string>("ChapterName");
        ChapterDescription.text = ES3.Load<string>("ChapterDescription");
        _curentJson = Mbt.GetDesiredJSONData(JsonCollectionSO);
        JsonCollectionSO.DataBase.Clear();
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
                TestGroupButtons.Add(obj.GetComponent<TestGroup>());
            }
            GridLayout.gameObject.SetActive(false);
            StartCoroutine(DisplayTestGroup());
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
}
