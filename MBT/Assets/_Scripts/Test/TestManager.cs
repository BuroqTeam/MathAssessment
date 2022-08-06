using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public GameObject PatternParent;
    public TMP_Text QuestionText;
    public PatternSO[] PatternGroup;
    public DataBaseSO[] Group;

    private PatternSO _patternSO;
    private DataBaseSO _jsonCollectionSO;
    private List<GameObject> activePatterns = new List<GameObject>();



    private void Awake()
    {
        if (ES3.Load<string>("Subject").Equals("Algebra"))
        {
            _patternSO = PatternGroup[0];
            _jsonCollectionSO = Group[0];
        }
        else
        {
            _patternSO = PatternGroup[1];
            _jsonCollectionSO = Group[1];
        }        
    }

    public virtual void DisplayQuestion(string questionStr)
    {
        QuestionText.text = questionStr;


    }

    void CreateExistedPatterns()
    {
        foreach (GameObject pattern in _patternSO.PatternPrefabs)
        {
            if (pattern.GetComponent<Pattern>().PatternID.Equals("dsd"))
            {
                GameObject obj = Instantiate(pattern);
                obj.transform.SetParent(PatternParent.transform);
                obj.transform.localScale = Vector3.one;
                activePatterns.Add(obj);
            }
           
        }
        
    }



}
