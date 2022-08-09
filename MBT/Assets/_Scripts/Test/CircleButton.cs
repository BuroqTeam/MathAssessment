using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CircleButton : MonoBehaviour
{
    public TEXDraw NumberText;
    [HideInInspector]
    public int Number;
    [HideInInspector]
    public GameObject _parent;
    Button btn;
    public Sprite[] sprites;
    public List<Button> buttonList = new();


    private void Awake()
    {
        btn = GetComponent<Button>();       
        btn.onClick.AddListener(TaskOnClick);
      
    }

    void TaskOnClick()
    {        
        Active();
        int k = 0;
        foreach (Button item in buttonList)
        {
            if (item != btn)
            {
                item.GetComponent<CircleButton>().DeActive();
            }
            else
            {
                TestManager.Instance.ActiveDesiredPattern(k);
            }
            k++;
        }
    }

    public void CollectCircles()
    {
        buttonList = _parent.transform.GetComponentsInChildren<Button>().ToList();
        TestManager.Instance.ActiveNumber.text = "1/" + buttonList.Count.ToString();
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

    public void Active()
    {
        if (Number != 0)
        {
            NumberText.text = Number.ToString();
            TestManager.Instance.ActiveNumber.text = Number.ToString() + "/" + buttonList.Count.ToString();
        }
        
        GetComponent<Image>().sprite = sprites[0];
        transform.GetChild(0).GetComponent<Image>().sprite = sprites[2];
    }

    public void DeActive()
    {
        GetComponent<Image>().sprite = null;
        transform.GetChild(0).GetComponent<Image>().sprite = sprites[3];
    }


    

}
