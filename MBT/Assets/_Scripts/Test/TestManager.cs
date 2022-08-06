using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject PatternParent;
    [HideInInspector]
    public TMP_Text QuestionText;
    public PatternSO[] PatternGroup;
    public DataBaseSO[] Group;

    protected PatternSO PatternSO;
    protected DataBaseSO JsonCollectionSO;
    private List<GameObject> _activePatterns = new List<GameObject>();
    private TextAsset _curentJson;
    private int _numberOfQuestions;
    private JObject _jo;


    private void Awake()
    {
        GetData();
        CountNumberOfQuestions();
    }

    public void GetData()
    {
        if (ES3.Load<string>("Subject").Equals("Algebra"))
        {
            PatternSO = PatternGroup[0];
            JsonCollectionSO = Group[0];
        }
        else
        {
            PatternSO = PatternGroup[1];
            JsonCollectionSO = Group[1];
        }

    }

    void CountNumberOfQuestions()
    {
        _curentJson = Mbt.GetDesiredJSONData(JsonCollectionSO);
        _jo = JObject.Parse(_curentJson.text);
        JArray questions = (JArray)_jo["chapters"][ES3.Load<int>("Chapter")]["questions"];
        IList<Question> questionGroup = questions.ToObject<IList<Question>>();

        string sample = questionGroup[0].pattern;
        _numberOfQuestions = 0;
        for (int i = 0; i < questionGroup.Count; i++)
        {            
            if (sample.Equals(questionGroup[i].pattern))
            {
                _numberOfQuestions++;
            }
        }

        CreateExistedPatterns();
    }

    public virtual void DisplayQuestion(string questionStr)
    {
        QuestionText.text = questionStr;
    }

    void CreateExistedPatterns()
    {
        JObject singleQuestion = new JObject();
        List<JObject> jsonList = new List<JObject>();
        int k = ES3.Load<int>("TestGroup");
        k--;
        for (int i = 0; i < _numberOfQuestions; i++)
        {            
            singleQuestion = (JObject)_jo["chapters"][ES3.Load<int>("Chapter")]["questions"][k];
            jsonList.Add(singleQuestion);
            k += _numberOfQuestions;           
        }

      
        foreach (GameObject pattern in PatternSO.PatternPrefabs)
        {
            foreach (JObject jObj in jsonList)
            {
                if (pattern.GetComponent<Pattern>().PatternID.Equals(jObj["pattern"].ToString()))
                {
                    Mbt.SaveJsonPath("Pattern_" + pattern.GetComponent<Pattern>().PatternID,
                        ES3.Load<int>("Chapter"),
                        ES3.Load<int>("TestGroup"));
                    GameObject obj = Instantiate(pattern);
                    obj.transform.SetParent(PatternParent.transform);
                    obj.transform.localScale = Vector3.one;
                    obj.SetActive(false);
                    _activePatterns.Add(obj);
                }
            }
        }
        _activePatterns[0].SetActive(true);
    }

    

}
