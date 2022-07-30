using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "DataBase", menuName = "ScriptableObjects/DataBase", order = 4)]
public class DataBaseSO : ScriptableObject
{
    public List<AssetReference> Class5 = new List<AssetReference>();
    public List<AssetReference> Class6 = new List<AssetReference>();
    public List<AssetReference> Class7 = new List<AssetReference>();
    public List<AssetReference> Class8 = new List<AssetReference>();
    public List<AssetReference> Class9 = new List<AssetReference>();
    public List<AssetReference> Class10 = new List<AssetReference>();
    public List<AssetReference> Class11 = new List<AssetReference>();
    

    public Dictionary<int, List<AssetReference>> DataBase = new Dictionary<int, List<AssetReference>>();

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
