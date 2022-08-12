using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public GameObject CirclePrefab;
    public GameObject CircleParent;
    public UnityEvent NewQuestionEvent;

    [HideInInspector]
    public List<Circle> CircleGroup = new();
    [HideInInspector]
    public int CurrentQuestionNumber, MaximumQuestionNumber;
    [HideInInspector]
    public Circle CurrentCircleObj;
    public static GameManager Instance;


    private void Awake()
    {
        Instance = this;
       
    }


    public void CreateCircles()
    {
       
        MaximumQuestionNumber = TestManager.Instance.ActivePatterns.Count;
        for (int i = 0; i < TestManager.Instance.ActivePatterns.Count; i++)
        {
            GameObject circle = Instantiate(CirclePrefab, CircleParent.transform.position, Quaternion.identity);
            circle.transform.SetParent(CircleParent.transform);
            circle.transform.localScale = Vector3.one;
            circle.GetComponent<Circle>().InitialCondition(i);
            CircleGroup.Add(circle.GetComponent<Circle>());
        }
        UpdateTestView(0, false);
        
    }


    public void UpdateTestView(int circleIdentity, bool IsNext)
    {       
        CircleGroup[CurrentQuestionNumber].MakeDone();
        CurrentQuestionNumber = circleIdentity;        
        CurrentCircleObj = CircleGroup[CurrentQuestionNumber];       
        CircleGroup[CurrentQuestionNumber].MakeActive();
        NewQuestionEvent.Invoke();
        if (IsNext)
        {
            SetActiveNextQuestion();
        }
        
    }

    void SetActiveNextQuestion()
    {
        foreach (GameObject obj in TestManager.Instance.ActivePatterns)
        {
            if (obj.activeSelf)
            {             
                TestManager.Instance.ActivePatterns[CurrentQuestionNumber].SetActive(true);
                obj.SetActive(false);
                break;
            }           
        }        
    }


}
