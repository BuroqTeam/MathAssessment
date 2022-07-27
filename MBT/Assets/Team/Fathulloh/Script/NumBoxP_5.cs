using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumBoxP_5 : MonoBehaviour
{
    public bool _OnCorrectPos;
    public GameObject NumberType;
    public string CurrentNum;
    public List<string> CurrentSolution;


    public GameObject CurrentObj;
    public bool _IsEmpty = true;


    void Start()
    {
        
    }


    public bool CheckAns(bool _isT, string str)
    {
        //bool _TF;
        if (_isT)
        {
            _IsEmpty = false;

            CurrentNum = str;
            for (int i = 1; i < CurrentSolution.Count; i++)
            {
                if (CurrentSolution[i] == str)
                {
                    Debug.Log("CorrectWay.");
                    _OnCorrectPos = true;
                } 
            }            
        }
        else if (!_isT)        {
            _IsEmpty = true;

            CurrentNum = null;
            _OnCorrectPos = false;            
        }

        return _OnCorrectPos;
    }




}
