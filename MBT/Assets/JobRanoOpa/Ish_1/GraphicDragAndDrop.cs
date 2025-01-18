using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LoyihaIshiBir
{
    /// <summary>
    /// This script is responsible for drag and drop graphics. 
    /// </summary>
    public class GraphicDragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform _rectTransform;   // Reference to the RectTransform of the image
        public Canvas CanvasObject;                // Reference to the parent Canvas
        private CanvasGroup _canvasGroup;      // For managing raycast blocking
        private Vector3 _originalPosition;     // To reset position if dropped incorrectly
        
        [Header("Target")]
        public GameObject AnswerObject; // Assign the correct drop target in the Inspector
        private GameObject _replacedObject;

        private void Start()
        {
            StartCoroutine(SetInitialThings());
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _originalPosition = _rectTransform.position;
            _canvasGroup.blocksRaycasts = false;  // Disable raycasts so the image doesn't block drop detection
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / CanvasObject.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;  // Enable raycasts again
            // If not dropped on a valid drop zone, return to original position
            if (AnswerObject != null)
            {
                if (Vector2.Distance(transform.position, AnswerObject.transform.position) < 2)
                {
                    Vector2 newPos = _replacedObject.GetComponent<RectTransform>().anchoredPosition;
                    _replacedObject.SetActive(false);
                    transform.SetParent(AnswerObject.transform);
                    _rectTransform.anchoredPosition = newPos;
                    _canvasGroup.blocksRaycasts = false;
                    _rectTransform.anchorMin = _replacedObject.GetComponent<RectTransform>().anchorMin/*new Vector2(0.5f, 0.5f)*/;
                    _rectTransform.anchorMax = _replacedObject.GetComponent<RectTransform>().anchorMax/*new Vector2(0.5f, 0.5f)*/;
                    Debug.Log("Set new pos");
                }
                else
                {
                    _rectTransform.position = _originalPosition;
                    Debug.Log("Return old pos");
                }
            }
            else
            {
                _rectTransform.position = _originalPosition;
                Debug.Log("Answer object is null");
            }            
            //if (!eventData.pointerEnter || eventData.pointerEnter.tag != "GraphicStory")
            //{                
            //}            
        }

        IEnumerator SetInitialThings()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _originalPosition = _rectTransform.anchoredPosition;
            yield return new WaitForSeconds(0.5f);
            _replacedObject = AnswerObject.transform.GetChild(0).gameObject;
        }

    }
}
