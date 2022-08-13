using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Result", menuName = "ScriptableObjects/Result", order = 3)]
public class ResultSO : ScriptableObject
{
    public float Percentage;
    public int Correct;
    public int Wrong;
}
