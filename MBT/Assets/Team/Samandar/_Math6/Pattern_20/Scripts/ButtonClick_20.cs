using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick_20 : MonoBehaviour
{
    public Pattern_20 Panel;

    public Sprite SpClicked;

    Sprite _spInitial;
    Button _button;

    public bool IsEnable;


    private void Awake()
    {
        _spInitial = GetComponent<Image>().sprite;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(TaskOnClick);
        PointSprite();
    }
    void PointSprite()
    {
        if (IsEnable == true)
        {
            GetComponent<Image>().sprite = GetComponent<ButtonClick_20>().SpClicked;
        }

    }


    public void TaskOnClick()
    {
        foreach (Button btn in Panel.Buttons)
        {
            if (_button.Equals(btn))
            {
                btn.GetComponent<Image>().sprite = btn.GetComponent<ButtonClick_20>().SpClicked;
                IsEnable = true;
            }
            else
            {

                btn.GetComponent<Image>().sprite = btn.GetComponent<ButtonClick_20>()._spInitial;
                btn.GetComponent<ButtonClick_20>().IsEnable = false;
            }

        }
        Panel.CheckToolIsEnable();
    }

}
