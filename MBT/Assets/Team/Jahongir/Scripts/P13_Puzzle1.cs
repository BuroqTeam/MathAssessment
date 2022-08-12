using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P13_Puzzle1 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public string QuestionId;
    public Pattern_13 Pattern13;
    public GameObject AttechedPuzzle;
    private int _selectedAnswerId = -1;
    private Vector3 _lastPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.GetChild(1).transform.DOScale(1.2f, 0);
        _lastPos = transform.GetChild(1).transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.GetChild(1).transform.position = new Vector3(pos.x, pos.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        for ( int i = 0; i < Pattern13.AnswerPuzles.Count; i++)
        {
            if (Vector2.Distance(transform.GetChild(1).transform.position, Pattern13.AnswerPuzles[i].transform.GetChild(1).transform.position) < 0.7f)
            {
                _selectedAnswerId = i;
            }
        }
        Debug.Log(_selectedAnswerId);
        if (_selectedAnswerId != -1)
        {
            transform.GetChild(1).transform.position = Pattern13.AnswerPuzles[_selectedAnswerId].transform.GetChild(1).transform.position;
            AttechedPuzzle = Pattern13.AnswerPuzles[_selectedAnswerId];
            transform.GetChild(1).transform.DOScale(1, 0);
        }
        else
        {
            transform.GetChild(1).transform.position = transform.GetChild(0).transform.position;
            transform.GetChild(1).transform.DOScale(1, 0);
        }
        _selectedAnswerId = -1;
        Pattern13.CheckButton();
    }
}
