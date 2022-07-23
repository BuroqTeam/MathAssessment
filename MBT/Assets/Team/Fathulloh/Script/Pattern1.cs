using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1 : MonoBehaviour
{
    public List<GameObject> ABCD;
    public GameObject QuestionObject;
    public TextAsset JsonText;

    //Pattern1Data Obj1 = new Pattern1Data();


    void Start()
    {

        WriteTest();
    }


    public void WriteTest()
    {
        var jsonObj = JObject.Parse(JsonText.text);

        //Obj1.title = jsonObj["chapters"][0]["questions"][3]["question"]["title"].Value<string>();
        //QuestionObject.GetComponent<TEXDraw>().text = Obj1.title;
        
        var likeObj = jsonObj["chapters"][0]["questions"][3]["question"].ToObject<Pattern1Data>();

        QuestionObject.GetComponent<TEXDraw>().text = likeObj.title;

        for (int i = 0; i < ABCD.Count; i++)
        {
            var likeName = jsonObj["chapters"][0]["questions"][3]["question"]["options"][i].Value<string>();

            ABCD[i].GetComponent<AnswerPattern1>().PatternOne = this;

            if (likeName.Contains('*'))
            {                
                //ABCD[i].GetComponent<AnswerPattern1>().ABCD = ABCD;
                ABCD[i].GetComponent<AnswerPattern1>()._IsTrue = true;
                likeName = likeName.Replace("[*]", "");
            }
            ABCD[i].GetComponent<AnswerPattern1>().WriteCurrentAnswer(likeName);
        }

        
    }



    public void UnClickedButtons()
    {
        for (int i = 0; i < ABCD.Count; i++)
        {
            ABCD[i].transform.GetChild(0).gameObject.SetActive(false);
            //ABCD[i].transform.GetComponent<AnswerPattern1>().Clicked.gameObject.SetActive(false);
        }
    }


}

[SerializeField]
public class Pattern1Data
{
    public string title;
    public List<string> options;
}
