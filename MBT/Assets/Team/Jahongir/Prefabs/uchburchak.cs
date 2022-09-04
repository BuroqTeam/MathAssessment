using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Uchburchak : MonoBehaviour, IPointerClickHandler
{
    public bool Select = false;
    public bool Selected;
    public Pattern_16 Pattern16;
    private void Start()
    {
        if (Selected)
        {
            transform.GetComponent<SpriteRenderer>().color = new Color32(0, 148, 255, 255);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Select)
        {
            transform.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 250);
            Select = false;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().color = new Color32(0, 148, 255, 255);
            Select = true;
        }
        Pattern16.CheckButton();
        Pattern16.Check();
    }
}
