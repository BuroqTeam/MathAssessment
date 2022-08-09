using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class P10_ButtonControl : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Pattern_10 Pattern10;
    public int Value;
    float _min;
    int _minValue;
    
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
        for (int i = 0; i < Pattern10.Tile1.Count; i++)
        {
            _min = Vector2.Distance(transform.position, Pattern10.Tile1[0].transform.position);
            if (_min >= Vector2.Distance(transform.position, Pattern10.Tile1[i].transform.position))
            {
                _min = Vector2.Distance(transform.position, Pattern10.Tile1[i].transform.position);
                _minValue = i;
            }
        }
        if (true)
        {
            Debug.Log("Tushdi");
            Debug.Log(Pattern10.Tile1[_minValue].transform.position.x);
            Debug.Log(transform.position.x);
        }
    }
}
