using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Newtonsoft.Json.Linq;

public class ChapterManager : MonoBehaviour
{   
    public AssetReference ChapterPrefab;
    public AssetReference[] JsonDataGroup;
    public GridLayoutGroup GridLayout;
    public int NumberOfChapter;
    public ScrollRect ScrollRectObj;
    public GameEvent UpdateEventSO;
    public TextAsset LocalJson;

    [HideInInspector]
    public List<Chapter> ChapterGorup = new List<Chapter>();

    private GameObject _chapterPrefabObj;
    private TextAsset _localJson;



    private void Awake()
    {
        ChapterPrefab.LoadAssetAsync<GameObject>().Completed += OnAssetLoaded;
        JsonDataGroup[PlayerPrefs.GetInt("LanguageID")].LoadAssetAsync<TextAsset>().Completed += JsonLoaded;

        SetScrollRect();

        // Read and DisplayChapters
    }

    void JsonLoaded(AsyncOperationHandle<TextAsset> obj)
    {
        _localJson = obj.Result;
        UpdateEventSO.Raise();
        ReadJSON();
    }

    void OnAssetLoaded(AsyncOperationHandle<GameObject> objAdd)
    {
        _chapterPrefabObj = objAdd.Result;
        
        for (int i = 0; i < NumberOfChapter; i++)
        {
            GameObject obj = Instantiate(_chapterPrefabObj, _chapterPrefabObj.transform.position, Quaternion.identity);
            obj.transform.SetParent(GridLayout.transform);
            obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            obj.GetComponent<RectTransform>().localPosition = new Vector3(obj.GetComponent<RectTransform>().localPosition.x, obj.GetComponent<RectTransform>().localPosition.y, 0);
        }

    }

    void SetScrollRect()
    {
        if (NumberOfChapter > 10)
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

    void ReadJSON()
    {
        var jo = JObject.Parse(LocalJson.text);

        JArray chapters = (JArray)jo["chapters"];

        Debug.Log(chapters.Count);

    }


}
