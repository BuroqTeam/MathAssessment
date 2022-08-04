using UnityEngine;
using UnityEngine.UI;

public class AnswerPattern_14 : MonoBehaviour
{
    public Pattern_14 Pattern14;
    public bool _PattenBool;
    public Color color;
    public ColorCollectionSO colorCollection;
    Button button;
    

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        foreach (Button btn in Pattern14.buttonGroup)
        {
            //if (button.Equals(btn))
            //{
            //    btn.GetComponent<Image>().color = color;
            //}
            //else
            //{
            //    btn.GetComponent<Image>().color = Color.white;
            //}
            if (button.Equals(btn))
            {
                btn.GetComponent<Image>().color = colorCollection.Blue;
                Debug.Log("ko'k");
            }
            else
            {
                btn.GetComponent<Image>().color = colorCollection.White;
            }
        }       
    }



    public void Check()
    {
        if (_PattenBool)
        {
            Debug.Log("Corrent");
        }
        else
        {
            Debug.Log("Wrong");
        }
        
    }

    
    
}
