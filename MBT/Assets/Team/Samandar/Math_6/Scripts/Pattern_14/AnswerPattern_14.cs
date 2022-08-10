using UnityEngine;
using UnityEngine.UI;

public class AnswerPattern_14 : MonoBehaviour
{
    public Pattern_14 Pattern14;
    public bool _PattenBool;
    Button button;
    public ColorCollectionSO colorCollection;
    public bool _Click = false;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        foreach (Button btn in Pattern14.buttonGroup)
        {
            if (Pattern14.buttonGroup.Count == 3)
            {
                if (button.Equals(btn))
                {
                    btn.GetComponent<Image>().color = colorCollection.Blue;
                    btn.gameObject.transform.GetChild(0).GetComponent<TEXDraw>().color = colorCollection.White;
                }
                                
                else
                {
                    btn.GetComponent<Image>().color = colorCollection.White;
                    btn.transform.GetChild(0).GetComponent<TEXDraw>().color = colorCollection.Green;
                }
            }
            else if (Pattern14.buttonGroup.Count == 2)
            {
                if (button.Equals(btn))
                {
                    btn.GetComponent<Image>().color = colorCollection.Blue;
                    btn.gameObject.transform.GetChild(0).GetComponent<TEXDraw>().color = colorCollection.White;
                }
                else
                {
                    btn.GetComponent<Image>().color = colorCollection.White;
                    btn.transform.GetChild(0).GetComponent<TEXDraw>().color = colorCollection.Green;
                    Pattern14.buttonGroup[1].transform.GetChild(0).GetComponent<TEXDraw>().color = colorCollection.Red;
                }
            }
            else
            {
                if (button.Equals(btn))
                {
                    btn.GetComponent<Image>().color = colorCollection.Blue;
                    btn.gameObject.transform.GetChild(0).GetComponent<TEXDraw>().color = colorCollection.White;
                }

                else
                {
                    btn.GetComponent<Image>().color = colorCollection.White;
                    btn.transform.GetChild(0).GetComponent<TEXDraw>().color = colorCollection.Green;
                }
            }
            
        }       
    }
    public void Check()
    {
        _Click = true;
        Pattern14._click = _Click;
        Pattern14._pattenBool = _PattenBool;
    }
}
