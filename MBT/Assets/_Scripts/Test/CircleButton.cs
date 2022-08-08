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
        foreach (Button item in buttonList)
        {
            if (item.Equals(btn))
            {
                
            }
        }
    }


}
