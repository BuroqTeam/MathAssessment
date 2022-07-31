using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_4F : TestManagerSample
{

    public TextAsset JsonText;
    private GameObject MainParent;
    public GameObject QuestionObj;

    public GameObject prefabArea;
    public GameObject prefDropDown;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}

[SerializeField]
public class Data_4F
{
    public string title;
    public List<Statement_4F> statments = new List<Statement_4F>();
    public List<Option_4F> options = new List<Option_4F>();
}

[SerializeField]
public class Statement_4F
{
    public string statement;
    public string image;
}

[SerializeField]
public class Option_4F
{
    public string left;
    public char sign;
    public string right;

}