using UnityEngine;
using UnityEngine.UI;

public class AnswerPattern_24 : MonoBehaviour
{
    public Pattern_24 Pattern24;
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
        foreach (Button btn in Pattern24.buttonGroup)
        {
            if (Pattern24.buttonGroup.Count == 3)
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
            else if (Pattern24.buttonGroup.Count == 2)
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
                    Pattern24.buttonGroup[1].transform.GetChild(0).GetComponent<TEXDraw>().color = colorCollection.Red;
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
        Pattern24.Active();
        Pattern24.Check();
    }
    public void Check()
    {
        _Click = true;
        Pattern24._click = _Click;
        Pattern24._pattenBool = _PattenBool;
    }
}
