using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FinishButton : MonoBehaviour
{
    //public GameObject PatternBorder;
    //public Timer TimerObject;
    //bool _isTrue = true;

    private void Awake()
    {
        gameObject.transform.DOScale(0, 0);
    }


    private void OnEnable()
    {
        UpdateResultView();
    }


    public void UpdateResultView()
    {        
        gameObject.transform.DOScale(1, 0.5f);
    }


    //void CheckingAllPattern()
    //{
    //    int totalEditedPatterns = 0;
    //    for (int i = 0; i < PatternBorder.transform.childCount; i++)
    //    {
    //        bool isEdited = PatternBorder.transform.GetChild(i).GetComponent<Pattern>().IsEdited;
    //        if (isEdited)
    //        {
    //            totalEditedPatterns++;                
    //        }
    //    }

    //    if ((_isTrue) && (totalEditedPatterns == 3/*PatternBorder.transform.childCount*/))
    //    {
    //        GetComponent<Image>().enabled = true;
    //        _isTrue = false;
    //        StartCoroutine(AnimationFinishButton(1.2f, 1));

    //    }
    //    else if ((!_isTrue) && (totalEditedPatterns != 3/*PatternBorder.transform.childCount*/))
    //    {            
    //        _isTrue = true;
    //        StartCoroutine(AnimationFinishButton(1.2f, 0));
    //        GetComponent<Image>().enabled = false;            
    //    }

    //    //if (TimerObject.timer < 550)
    //    //{
    //    //    gameObject.GetComponent<Button>().onClick.Invoke();
    //    //}
    //}


    //IEnumerator AnimationFinishButton(float num1, float num2)
    //{
    //    gameObject.transform.DOScale(num1, 0.2f);
    //    yield return new WaitForSeconds(0.2f);

    //    gameObject.transform.DOScale(num2, 0.2f);
    //    yield return new WaitForSeconds(0.2f);
    //}


}

