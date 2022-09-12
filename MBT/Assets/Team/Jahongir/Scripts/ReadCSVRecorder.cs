using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ReadCSVRecorder : MonoBehaviour
{
    public AssetReference AddressableDataCSV;
    public TextAsset LocalDataCSV;
    private ItemList _linkList = new ItemList();

    private void Awake()
    {
        //AddressableDataCSV.LoadAssetAsync<TextAsset>().Completed += OnTextJsonLoaded;
    }

    private void OnTextJsonLoaded(AsyncOperationHandle<TextAsset> obj)
    {
        LocalDataCSV = obj.Result;
        //ReadCSV();
    }


    void ReadCSV()
    {
        string[] data = LocalDataCSV.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);
        int tableSize = data.Length / 2 - 1;
        _linkList.ItemGroup = new Item[tableSize].ToList();

        for (int i = 0; i < tableSize; i++)
        {
            _linkList.ItemGroup[i] = new Item();
            _linkList.ItemGroup[i].Key = data[2 * (i + 1)];
            _linkList.ItemGroup[i].Value = data[2 * (i + 1) + 1];
        }
        SetLinkForButton();
    }

    void SetLinkForButton()
    {
        foreach (Item item in _linkList.ItemGroup)
        {
            if (item.Key != null)
            {
                if (item.Key.Equals(ES3.Load<string>("Subject") + "/" + ES3.Load<int>("ClassKey") + "/" + ES3.Load<int>("Chapter") + "/" + ES3.Load<int>("TestGroup")))
                {
                    GetComponent<WebLinkOpen>().WebLink = item.Value;
                    break;
                }
            }
        }
    }


}



[System.Serializable]
public class Item
{
    public string Key;
    public string Value;

}

[System.Serializable]
public class ItemList
{
    public List<Item> ItemGroup = new List<Item>();
}
