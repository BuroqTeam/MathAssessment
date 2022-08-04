using TMPro;
using UnityEngine;

public class TextColorable : MonoBehaviour
{
    public ColorCollectionSO colorSO;
    TMP_Text percentageTxt;

    private void Awake()
    {
        percentageTxt = GetComponent<TMP_Text>();
        if (percentageTxt.text != "0%")
        {
            percentageTxt.color = colorSO.Blue;
        }
        else
        {
            percentageTxt.color = colorSO.DarkBlue;
        }
    }

}
