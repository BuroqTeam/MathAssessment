using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1Manager : MonoBehaviour
{
    public List<GameObject> ABCD;
    public GameObject QuestionObject;

    void Start()
    {
        //WriteTest();
    }

    public void WriteTest()
    {
        for (int i = 0; i < ABCD.Count; i++)
        {
            ABCD[i].transform.GetComponent<TEXDraw>().text = "str";
        }
        QuestionObject.transform.GetChild(0).GetComponent<TEXDraw>().text = "savol";
    }





}
