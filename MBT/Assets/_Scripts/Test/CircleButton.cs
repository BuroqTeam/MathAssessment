using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CircleButton : MonoBehaviour
{
    [HideInInspector]
    public GameObject _parent;
    Button btn;
    public Sprite[] sprites;
    List<Button> buttonList = new();


    private void Awake()
    {
        btn = GetComponent<Button>();       
        btn.onClick.AddListener(TaskOnClick);
      
    }

    void TaskOnClick()
    {
        Active();
        foreach (Button item in buttonList)
        {
            if (item != btn)
            {
                DeActive();                
            }
        }
    }

    public void CollectCircles()
    {
        buttonList = _parent.transform.GetComponentsInChildren<Button>().ToList();
    }


    public void InitialCondition(int index, GameObject parent)
    {
        _parent = parent;
        if (index.Equals(0))
        {
            Active();
        }
        else
        {
            DeActive();
        }
    }

    void Active()
    {
        GetComponent<Image>().sprite = sprites[0];
        transform.GetChild(0).GetComponent<Image>().sprite = sprites[2];
    }

    void DeActive()
    {
        GetComponent<Image>().sprite = null;
        transform.GetChild(0).GetComponent<Image>().sprite = sprites[3];
    }

}
