using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class TestGroupManager : MonoBehaviour
{
  
    public AssetReference[] JsonDataGroup;
    public GridLayoutGroup GridLayout;
    public ScrollRect ScrollRectObj;
    public GameEvent UpdateEventSO;
    public GameObject UpdatePanel;

    //[HideInInspector]
    public List<TestGroup> TestGroupPrefabGorup = new List<TestGroup>();

    public GameObject TestGroupObj;
    private TextAsset _localJson;
    private int _numberOfTestGroup;
    IList<TestGroupRaw> _testGroup;


    private void Awake()
    {
        JsonDataGroup[ES3.Load<int>("LanguageID")].LoadAssetAsync<TextAsset>().Completed += JsonLoaded;
        DisableLoadingBar();
    }

    void DisableLoadingBar()
    {
        if (ES3.KeyExists("IsInitialLoad"))
        {
            if (ES3.Load<bool>("IsInitialLoad"))
            {
                UpdatePanel.SetActive(false);
            }
        }

    }



    void JsonLoaded(AsyncOperationHandle<TextAsset> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            _localJson = obj.Result;
            ReadJSON();
        }

    }

   

    void ReadJSON()
    {
        var jo = JObject.Parse(_localJson.text);
        JArray testGroup = (JArray)jo["chapters"];
        _numberOfTestGroup = testGroup.Count;
        _testGroup = testGroup.ToObject<IList<TestGroupRaw>>();
        CreateChapters();
        SetScrollRect();
    }


    void SetScrollRect()
    {
        if (_numberOfTestGroup > 10)
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



    void CreateChapters()
    {
        if (_numberOfTestGroup > 0)
        {
            for (int i = 0; i < _numberOfTestGroup; i++)
            {
                GameObject obj = Instantiate(TestGroupObj);
                obj.transform.SetParent(GridLayout.transform);
                obj.transform.localScale = Vector3.one;
                TestGroupPrefabGorup.Add(obj.GetComponent<TestGroup>());
            }
            GridLayout.gameObject.SetActive(false);
            StartCoroutine(DisplayTestGroup());
        }

    }

    IEnumerator DisplayTestGroup()
    {
        ES3.Save("IsInitialLoad", true);
        yield return new WaitForSeconds(0.1f);
        GridLayout.gameObject.SetActive(true);
        int k = 0;
        foreach (TestGroupRaw item in _testGroup)
        {
            TestGroupPrefabGorup[k].RawTestGroup.number = item.number;           
            k++;
        }
        foreach (TestGroup item in TestGroupPrefabGorup)
        {
            item.UpdateInfo();
        }
        UpdateEventSO.Raise();
    }
}
