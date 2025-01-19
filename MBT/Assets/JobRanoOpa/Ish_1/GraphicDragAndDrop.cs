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
        public LoyihaBir LoyihaBirManager;
        public Canvas CanvasObject;            // Reference to the parent Canvas
        private CanvasGroup _canvasGroup;      // For managing raycast blocking
        private Vector3 _originalPosition;     // To reset position if dropped incorrectly
        private RectTransform _rectTransform;  // Reference to the RectTransform of the image
        
        [HideInInspector] public int GraphicOrder;
        public GameObject AnswerObject;        // Assign the correct drop target in the Inspector
        [Header("Target")]
        private GameObject _targetObject;


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
            
            if (AnswerObject != null)
            {
                float distan = Vector2.Distance(transform.position, _targetObject.transform.position);
                //Debug.Log("transform.position = " + transform.position);
                if (distan < 1.5f)
                {
                    Vector2 targetPos = _targetObject.GetComponent<RectTransform>().anchoredPosition;
                    _targetObject.SetActive(false);
                    transform.SetParent(AnswerObject.transform);
                    _rectTransform.anchoredPosition = targetPos;
                    _canvasGroup.blocksRaycasts = false;
                    _rectTransform.anchorMin = _targetObject.GetComponent<RectTransform>().anchorMin;
                    _rectTransform.anchorMax = _targetObject.GetComponent<RectTransform>().anchorMax;

                    LoyihaBirManager.CorrectEvent.Invoke();
                    LoyihaBirManager.NextTask(GraphicOrder);
                }
                else
                {
                    _rectTransform.position = _originalPosition;
                    LoyihaBirManager.WrongEvent.Invoke();
                    //Debug.Log("Return old pos = " + Vector2.Distance(transform.position, AnswerObject.transform.position));
                }
            }
            else
            {
                _rectTransform.position = _originalPosition;
                LoyihaBirManager.WrongEvent.Invoke();
            }            
            
        }

        IEnumerator SetInitialThings()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _originalPosition = _rectTransform.anchoredPosition;
            yield return new WaitForSeconds(0.5f);
            if (AnswerObject != null)
            {
                _targetObject = AnswerObject.transform.GetChild(0).gameObject;
            }
            
        }


    }
}
