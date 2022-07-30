using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ActivePattern", menuName = "ScriptableObjects/Pattern", order = 2)]
public class PatternSO : ScriptableObject
{
    public List<GameObject> PatternPrefabs = new List<GameObject>();
    public Dictionary<int, GameObject> ActivePatterns = new Dictionary<int, GameObject>();


    private void Awake()
    {
        int k = 1;
        foreach (GameObject item in PatternPrefabs)
        {
            ActivePatterns.Add(k, item);
            k++;
        }
        
    }
    
    
}
