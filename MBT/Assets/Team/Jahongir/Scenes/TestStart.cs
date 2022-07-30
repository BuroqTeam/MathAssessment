using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TestStart : MonoBehaviour
{
   
    public DataBaseSO dataBase;



    // Start is called before the first frame update

    void Awake()
    {
        dataBase.CreateDict();
        ES3.Save<string>("LanguageKey", "Class_6_Kaz");
        ES3.Save<int>("ClassKey", 6);

        string currentLanguage = ES3.Load<string>("LanguageKey");
        int currentClass = ES3.Load<int>("ClassKey");

        Dictionary<int, List<AssetReference>> JSONCOllection = new Dictionary<int, List<AssetReference>>();
        JSONCOllection = dataBase.DataBase;

        Debug.Log(JSONCOllection.Count);




        List<AssetReference> list = new List<AssetReference>();
        if (JSONCOllection.TryGetValue(currentClass, out list))
        {
            foreach (AssetReference txtAsset in list)
            {
                if (txtAsset.editorAsset.name.Equals(currentLanguage))
                {
                     
                    Debug.Log(txtAsset.editorAsset.name);
                }
            }
        }

    }


   
}
