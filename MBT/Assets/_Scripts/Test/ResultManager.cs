using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public ResultSO ResultSO;

    public TMP_Text Percentage;
    public TMP_Text Correct;
    public TMP_Text Wrong;
    public GameObject Panel;

    private void Awake()
    {
        Panel.transform.DOScale(0, 0);
    }

    private void OnEnable()
    {
        UpdateResultView();
    }


    public void UpdateResultView()
    {
        Percentage.text = ResultSO.Percentage.ToString();
        Correct.text = ResultSO.Correct.ToString();
        Wrong.text = ResultSO.Wrong.ToString();
        Panel.transform.DOScale(1, 1);
    }

    


}
