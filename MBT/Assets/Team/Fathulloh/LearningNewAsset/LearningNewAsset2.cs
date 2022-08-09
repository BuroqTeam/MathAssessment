using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningNewAsset2 : MonoBehaviour
{
    public GameObject SpriteObj;
    //public GameObject CanvasObj;
    void Start()
    {
        
    }


    public void LoadGameObject()
    {
        GameObject gameObje = ES3.Load("GameObjectSave_F", SpriteObj);
        gameObje.transform.SetParent(this.transform);
        Debug.Log("GameObject is loaded.");
    }


}
