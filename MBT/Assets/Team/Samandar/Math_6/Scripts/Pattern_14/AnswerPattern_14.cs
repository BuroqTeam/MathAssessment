using UnityEngine;
using UnityEngine.UI;

public class AnswerPattern_14 : MonoBehaviour
{
    public Pattern_14 Pattern14;
    public bool PattenBool;
    public Color blueColor;

    Button button;
    

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        foreach (Button btn in Pattern14.buttonGroup)
        {
            if (button.Equals(btn))
            {
                btn.GetComponent<Image>().color = blueColor;
            }
            else
            {
                btn.GetComponent<Image>().color = Color.white;
            }
        }       
    }



    public void Check()
    {
        //GetComponent<Image>().color = new Color(0, 0.5803922f, 1, 1);
        //gameObject.GetComponent<Image>().color
    }

    
    
}
