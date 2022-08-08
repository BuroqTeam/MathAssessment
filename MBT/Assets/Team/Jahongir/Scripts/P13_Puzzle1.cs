using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P13_Puzzle1 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public string QuestionId;
    public Pattern_13 Pattern13;

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.DOScale(1.2f, 0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        for ( int i = 0; i < Pattern13.AnswerPuzles.Count; i++)
        {
            Debug.Log(Vector2.Distance(transform.position, Pattern13.AnswerPuzles[i].transform.GetChild(1).transform.position));
            if (Vector2.Distance(transform.position, Pattern13.AnswerPuzles[i].transform.GetChild(1).transform.position) < 0.7f)
            {
                transform.DOScale(1, 0);
                Debug.Log("Tushdi");
            }
            else
            {
                transform.DOScale(0.8f, 0);
                Debug.Log("Tushmadi");
            }
        }
    }
}
