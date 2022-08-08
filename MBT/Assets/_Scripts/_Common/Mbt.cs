using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace MBT.Extension
{
    public static class Mbt
    {

        public static TextAsset GetDesiredJSONData(DataBaseSO dataBase)
        {
            TextAsset textAsset = new();
            dataBase.CreateDict();
            string currentLanguage = ES3.Load<string>("LanguageKey");
            int currentClass = ES3.Load<int>("ClassKey");
            Dictionary<int, List<TextAsset>> JsonDictionary = new(dataBase.DataBase);            
            List<TextAsset> list = new();
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

        public static TextAsset GetDesiredData(DataBaseSO dataBase)
        {
            TextAsset textAsset = new();           
            string currentLanguage = ES3.Load<string>("LanguageKey");
            int currentClass = ES3.Load<int>("ClassKey");
            Dictionary<int, List<TextAsset>> JsonDictionary = new(dataBase.DataBase);
            List<TextAsset> list = new();
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
            int[] array = ES3.Load<int[]>(key);
            JObject json = (JObject)jsonObj["chapters"][array[0]]["questions"][array[1]]["question"];
            return json;
        }


      
    }

}

