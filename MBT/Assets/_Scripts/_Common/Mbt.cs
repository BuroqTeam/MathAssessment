using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MBT.Extension
{
    public static class Mbt
    {

        public static AssetReference GetDesiredJSON(DataBaseSO dataBase)
        {
            AssetReference textAsset = new AssetReference();
            dataBase.CreateDict();
            string currentLanguage = ES3.Load<string>("LanguageKey");
            int currentClass = ES3.Load<int>("ClassKey");
            Dictionary<int, List<AssetReference>> JsonDictionary = new Dictionary<int, List<AssetReference>>();
            JsonDictionary = dataBase.DataBase;
            List<AssetReference> list = new List<AssetReference>();
            if (JsonDictionary.TryGetValue(currentClass, out list))
            {
                foreach (AssetReference txtAsset in list)
                {
                    if (txtAsset.editorAsset.name.Equals(currentLanguage))
                    {
                        textAsset = txtAsset;
                    }
                }
            }
            return textAsset;
        }




        public static void SaveJsonPath(int chapterID, int questionsId)
        {
            int[] array = new int[2] { chapterID, questionsId };
            ES3.Save<int[]>("SaveJsonPath", array);
        }

        public static JObject LoadJsonPath(JObject jsonObj)
        {
            JObject json = new JObject();
            int[] array = ES3.Load<int[]>("SaveJsonPath");
            json = (JObject)jsonObj["chapters"][array[0]]["questions"][array[1]]["question"];
            return json;
        }


    }

}

