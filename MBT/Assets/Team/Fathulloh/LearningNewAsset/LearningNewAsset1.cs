using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningNewAsset1 : MonoBehaviour
{
    readonly List<string> _programLanguages = new() { "Php", "C#", "C++", "Ruby", "Python", "Java" };
    public List<string> PLanguages;
    
    [ES3Serializable]
    public GameObject TextObj;
    public GameObject SpriteObj;

    [ES3Serializable]
    public List<GameObject> TextObjects;


    void Start()
    {        
        //SaveInt();
        //SaveListArray();
        SaveGameObject();
    }

    //public int LoadedNumber;

    void SaveInt()    // float tipli data save qilib uni yana qayta load qilingan metod.
    {
        int nulValue = 0;
        //ES3.Save("myIntF", 8000);
        int myInt = ES3.Load("myIntF", nulValue);
        Debug.Log("myIntF = " + myInt);

        ES3.Save("myIntF", 2022);

        Debug.Log("Yangi " + ES3.Load("myIntF"));        
    }


    void SaveListArray()// Listni saqlash va load qilib olish.
    {
        ES3.Save("programmingLanguages", _programLanguages);

        if (ES3.KeyExists("programmingLanguages"))
        {            
            PLanguages = ES3.Load("programmingLanguages", _programLanguages);
            Debug.Log("Data bor.");
        }
        else
        {
            Debug.Log("Data yo'q.");
        }
    }


    void SaveGameObject()
    {
        GameObject newObject = SpriteObj;
        ES3.Save("GameObjectSave_F", newObject);

        if (ES3.KeyExists("GameObjectSave_F"))
        {
            //ES3.LoadInto("GameObjectSave_F", this.transform);
            //GameObject gameObj = ES3.Load("GameObjectSave_F", TextObj);
            //gameObj.transform.SetParent(this.transform);
            Debug.Log("GameObjectSave_F bor.");
        }
        else
        {
            Debug.Log("GameObjectSave_F yo'q");
        }
        //Destroy(TextObj);
    }

    
    public void LoadGameObject()
    {        
        //GameObject gameObj = ES3.Load("GameObjectSave_F", defaultObj1);
        //var settings = new ES3Settings(ES3.EncryptionType.None, "myPassword");
        //GameObject gameObj = ES3.Load<GameObject>("GameObjectSave_F"/*, settings*/);

        GameObject gameObje = ES3.Load("GameObjectSave_F", SpriteObj);
        gameObje.transform.SetParent(this.transform);
        Debug.Log("GameObject is loaded.");
    }



}
