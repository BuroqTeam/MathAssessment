using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MBT.Extension
{
    public static class Mbt
    {



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

