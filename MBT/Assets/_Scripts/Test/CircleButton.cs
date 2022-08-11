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
    public bool isActive;


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
        _parent.GetComponent<QuestionOrderManager>().CircleButtons = new List<Button>(buttonList);
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
        foreach (Button item in buttonList)
        {
            if (item == btn)
            {
                item.GetComponent<CircleButton>().isActive = true;
            }
            else
            {
                item.GetComponent<CircleButton>().isActive = false;
            }            
        }
    }

    public void DeActive()
    {
        isActive = false;
        GetComponent<Image>().sprite = null;
        transform.GetChild(0).GetComponent<Image>().sprite = sprites[3];
    }


    

}
