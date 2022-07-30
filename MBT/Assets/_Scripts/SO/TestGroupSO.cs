using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestGroup", menuName = "ScriptableObjects/TestGroup", order = 3)]
public class TestGroupSO : ScriptableObject
{
    public JArray questions;
    public int NumberOfTestGroup;
    public string Name;
    public string Description;


}
