using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace MBT.Extension
{
    public static class Mbt
    {

        public static TextAsset GetDesiredJSONData(DataBaseSO dataBase)
        {
            TextAsset textAsset = new TextAsset();
            dataBase.CreateDict();
            string currentLanguage = ES3.Load<string>("LanguageKey");
            int currentClass = ES3.Load<int>("ClassKey");
            Dictionary<int, List<TextAsset>> JsonDictionary = new Dictionary<int, List<TextAsset>>(dataBase.DataBase);
            List<TextAsset> list = new List<TextAsset>();
            if (JsonDictionary.TryGetValue(currentClass, out list))
            {
                foreach (TextAsset txtAsset in list)
                {
                    if (txtAsset.name.Equals(currentLanguage))
                    {
                        textAsset = txtAsset;
                    }
                }
            }
            return textAsset;
        }


        public static void SaveJsonPath(string key, int chapterID, int questionsId)
        {
            int[] array = new int[2] { chapterID, questionsId };
            ES3.Save<int[]>(key, array);
        }

        public static JObject LoadJsonPath(JObject jsonObj, string key)
        {
            JObject json = new JObject();
            int[] array = ES3.Load<int[]>(key);
            json = (JObject)jsonObj["chapters"][array[0]]["questions"][array[1]]["question"];
            return json;
        }


      
    }

}

