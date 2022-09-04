using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionNumber : MonoBehaviour
{
    
    public int Index;
    public Sprite SpriteON;
    public Sprite SpriteOFF;
    public bool IsAnimationable;
    public TMP_Text NumberText;
    public Color BlueColor;

    Button _btn;
    
    
    

    private void Awake()
    {
        NumberText = transform.GetChild(0).GetComponent<TMP_Text>();
        BlueColor = NumberText.color;
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        PlayAnimation();
        GameManager.Instance.CurrentQuestionNumber = Index;
        GameManager.Instance.SetActiveNextQuestion();
    }


    public void InitialCondition(int number)
    {
        Index = number;
        number++;
        NumberText.text = number.ToString();
    }

    
    IEnumerator AnimateQuestionNumber()
    {
        if (IsAnimationable)
        {
            transform.DOScale(0.9f, 0.2f);
            yield return new WaitForSeconds(0.2f);
            transform.DOScale(1, 0.2f);
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(AnimateQuestionNumber());
        }
    }
    public void PlayAnimation()
    {
        foreach (QuestionNumber questionNumber in GameManager.Instance.QuestionNumbers)
        {
            if (questionNumber != this)
            {
                if (questionNumber.IsAnimationable)
                {
                    questionNumber.StopAnimation();
                    if (!TestManager.Instance.ActivePatterns[questionNumber.Index].GetComponent<Pattern>().IsEdited)
                    {
                        questionNumber.GetComponent<Image>().sprite = questionNumber.SpriteOFF;
                        questionNumber.NumberText.color = questionNumber.BlueColor;
                    }
                }
            }
        }
        IsAnimationable = true;
        GetComponent<Image>().sprite = SpriteON;
        NumberText.color = Color.white;
        StartCoroutine(AnimateQuestionNumber());
    }

    public void StopAnimation()
    {
        IsAnimationable = false;
    }

  
}
