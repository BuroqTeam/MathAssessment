using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CircleButton : MonoBehaviour
{
    GameObject _parent;
    Button btn;
    public Sprite[] sprites;
    List<Button> buttonList = new();


    private void Awake()
    {
        btn = GetComponent<Button>();
        _parent = transform.parent.gameObject;
        btn.onClick.AddListener(TaskOnClick);
        buttonList = _parent.transform.GetComponentsInChildren<Button>().ToList();
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


    public void InitialCondition(int index)
    {
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
