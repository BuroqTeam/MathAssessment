using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class P10_ItemSlot : MonoBehaviour, IDropHandler
{
    public int Index;
    public float CollectedNumber;
    public Pattern_10 Pattern10;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.transform.SetParent(Pattern10.Tile1[Index - 1].transform);
            Pattern10.CollectedPrefabs.Add(eventData.pointerDrag);
            if (transform.childCount > 9)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().localScale = transform.GetChild(1).GetComponent<RectTransform>().localScale;
                for (int i = 1; i < transform.childCount; i++)
                {
                    transform.GetChild(i).GetComponent<RectTransform>().localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                }
                GetComponent<HorizontalLayoutGroup>().spacing -= 15;
            }
            else
            {
                eventData.pointerDrag.GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
            DeactivationPrefabs();
            Pattern10.Result();
            Pattern10.Check();
        }
    }
    public void DeactivationPrefabs()
    {
        for (int i = 0; i < Pattern10.CollectedPrefabs.Count; i++)
        {
            if (Pattern10.CollectedPrefabs[i].GetComponent<P10_ButtonControl>().enabled)
            {
                Pattern10.CollectedPrefabs[i].GetComponent<P10_ButtonControl>().enabled = false;
            }
        }
    }
}
