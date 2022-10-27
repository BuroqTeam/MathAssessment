using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quarters : MonoBehaviour
{
    public Pattern_18 Pattern_18;
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }
    public void Chorak_1()
    {
        Pattern_18.ChorakNumber = null;
        Pattern_18.ChorakNumber = 1.ToString();
        Pattern_18.Check();
        gameObject.transform.GetComponent<Image>().color = Color.red;
    }
    public void Chorak_2()
    {
        Pattern_18.ChorakNumber = null;
        Pattern_18.ChorakNumber = 2.ToString();
        Pattern_18.Check();
        gameObject.transform.GetComponent<Image>().color = Color.red;
    }
    public void Chorak_3()
    {
        Pattern_18.ChorakNumber = null;
        Pattern_18.ChorakNumber = 3.ToString();
        Pattern_18.Check();
        gameObject.transform.GetComponent<Image>().color = Color.red;
    }
    public void Chorak_4()
    {
        Pattern_18.ChorakNumber = null;
        Pattern_18.ChorakNumber = 4.ToString();
        Pattern_18.Check();
        gameObject.transform.GetComponent<Image>().color = Color.red;
    }

    public void TaskOnClick()
    {
        foreach (Button btn in Pattern_18.Choraklar)
        {           
             if (button.Equals(btn))
             {
                 btn.GetComponent<Image>().color = new Color(0.8490566f ,0.8490566f ,0.8490566f , 1);
             }
             else
             {
                 btn.GetComponent<Image>().color = Color.white;
             }            
        }
    }
}
