using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionNumber : MonoBehaviour
{
    
    public int Index;
    Button btn;



    TMP_Text _numberText;

    private void Awake()
    {
        _numberText = transform.GetChild(0).GetComponent<TMP_Text>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);


    }

    void TaskOnClick()
    {
        GameManager.Instance.CurrentQuestionNumber = Index;
        GameManager.Instance.SetActiveNextQuestion();
    }


    public void InitialCondition(int number)
    {
        Index = number;
        number++;
        _numberText.text = number.ToString();


    }
   
}
