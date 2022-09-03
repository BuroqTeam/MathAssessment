using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
public class P10_ButtonControl : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Pattern_10 Pattern10;
    public float Value;
    public GameObject CanvasObj;
    private RectTransform _rectTransform;
    private  Vector3 _lastRectTransform;
    private CanvasGroup _canvasGroup;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _lastRectTransform = GetComponent<RectTransform>().anchoredPosition;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.DOScale(1f, 0);
        GameObject obj = Instantiate(gameObject, gameObject.transform.parent);
        obj.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        _canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / CanvasObj.GetComponent<Canvas>().scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.DOScale(0.7f, 0);
        _canvasGroup.blocksRaycasts = true;
        GetComponent<RectTransform>().anchoredPosition = _lastRectTransform;
        Pattern10.Result();
        Pattern10.DeleteWrongPrefab();
    }
}
