using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "DataBase", menuName = "ScriptableObjects/DataBase", order = 4)]
public class DataBaseSO : ScriptableObject
{
    public List<TextAsset> Class5 = new List<TextAsset>();
    public List<TextAsset> Class6 = new List<TextAsset>();
    public List<TextAsset> Class7 = new List<TextAsset>();
    public List<TextAsset> Class8 = new List<TextAsset>();
    public List<TextAsset> Class9 = new List<TextAsset>();
    public List<TextAsset> Class10 = new List<TextAsset>();
    public List<TextAsset> Class11 = new List<TextAsset>();
    

    public Dictionary<int, List<TextAsset>> DataBase = new Dictionary<int, List<TextAsset>>();

    public void CreateDict()
    {
        DataBase.Add(5, Class5);
        DataBase.Add(6, Class6);
        DataBase.Add(7, Class7);
        DataBase.Add(8, Class8);
        DataBase.Add(9, Class9);
        DataBase.Add(10, Class10);
        DataBase.Add(11, Class11);
    }

}
