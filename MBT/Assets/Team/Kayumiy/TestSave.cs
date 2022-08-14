using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSave : MonoBehaviour
{

    public GameObject button;


    // Start is called before the first frame update
    void Start()
    {


        ES3.Save(button.name, button);
        
    }

    void OnDisable()
    {
        Debug.Log("PrintOnDisable: script was disabled");
    }

    public void LoadGO()
    {
        ES3.Load("Button", gameObject);

    }
}
