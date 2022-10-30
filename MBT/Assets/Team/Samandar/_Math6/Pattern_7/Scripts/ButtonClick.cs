using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Pattern_7 Panel;
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
            GetComponent<Image>().sprite = GetComponent<ButtonClick>().SpClicked;
        }
    }

    public void TaskOnClick()
    {
        foreach (Button btn in Panel.Buttons)
        {
            if (_button.Equals(btn))
            {
                btn.GetComponent<Image>().sprite = btn.GetComponent<ButtonClick>().SpClicked;
                IsEnable = true;                             
            }
            else
            {
                btn.GetComponent<Image>().sprite = btn.GetComponent<ButtonClick>()._spInitial;
                btn.GetComponent<ButtonClick>().IsEnable = false;
            }
        }
        Panel.CheckToolIsEnable();
    }
}
