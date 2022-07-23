using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DegnDropPattern_3 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public List<GameObject> NumberArea;
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
            //float flov_1 = Vector3.Distance();
            ////Debug.Log(NumberArea[i].name + "        " + NumberArea.Count);
            //Debug.Log(flov_1);
            
            if (Vector3.Distance(gameObject.GetComponent<RectTransform>().rect.position, NumberArea[i].GetComponent<RectTransform>().rect.position) <= 36)
            {
                Debug.Log(1);
                transform.position = NumberArea[i].transform.position;
                break;
            }
        }
     
    }  
    // Update is called once per frame
    void Update()
    {
        
    }
}
