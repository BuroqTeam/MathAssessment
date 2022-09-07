using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PatternResult : MonoBehaviour      //F++
{
    public GameObject NumberPrefab;
    public ColorCollectionSO ColorSO;
    public List<bool> ResultList;

    void Start()
    {
        PatternFinishResult();
    }

    /// <summary>
    /// Qaysi Patternlar xato ishlanganini aniqlab Result Panelga chiqarib beruvchi metod.
    /// </summary>
    void PatternFinishResult()  
    {
        ResultList = new(ES3.Load<List<bool>>("ResultList"));
        for (int i = 0; i < ResultList.Count; i++)
        {
            GameObject questionNumber = Instantiate(NumberPrefab, this.transform.position, Quaternion.identity);
            questionNumber.transform.SetParent(this.transform);
            questionNumber.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); //
            questionNumber.GetComponent<Button>().enabled = false;
            questionNumber.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60);

            questionNumber.transform.GetChild(0).GetComponent<TMP_Text>().text = (i + 1).ToString();
            questionNumber.transform.GetChild(0).GetComponent<TMP_Text>().color = ColorSO.White;
            questionNumber.transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 50;

            if (ResultList[i])
            {
                questionNumber.GetComponent<Image>().color = ColorSO.Blue;
            }
            else
            {
                questionNumber.GetComponent<Image>().color = ColorSO.Red;
            }
        }
    }


}
