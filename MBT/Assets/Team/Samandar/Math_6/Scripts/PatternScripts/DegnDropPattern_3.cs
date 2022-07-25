using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DegnDropPattern_3 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public List<GameObject> NumberArea;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Check();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, 0);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Check()
    {
        for (int i = 0; i < NumberArea.Count; i++)
        {
            //if (Vector3.Distance(gameObject.transform.GetComponent<RectTransform>().rect.position, NumberArea[i].transform.GetComponent<RectTransform>().rect.position) <=35)
            //{
            //    gameObject.transform.position = NumberArea[i].transform.position;
            //    break;
            //}
            if (Vector3.Distance(gameObject.transform.GetComponent<RectTransform>().anchoredPosition, NumberArea[i].transform.GetComponent<RectTransform>().anchoredPosition) <= 35)
            {
                gameObject.GetComponent<RectTransform>().anchoredPosition = NumberArea[i].GetComponent<RectTransform>().anchoredPosition;
                break;
            }
            Debug.Log(Vector3.Distance(gameObject.transform.GetComponent<RectTransform>().anchoredPosition, NumberArea[i].transform.GetComponent<RectTransform>().anchoredPosition));
        }


    }
}
