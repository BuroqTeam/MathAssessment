using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
        private Image _imageObj;

        [HideInInspector] public int GraphicOrder;
        public GameObject AnswerObject;        // Assign the correct drop target in the Inspector
        [Header("Target")]
        private GameObject _targetObject;
        private Color _errorColor = new Color(0.89f, 0.65f, 0.65f, 1);
        private Color _correctColor = new Color(0.76f, 0.92f, 0.81f, 1);
        private Color _whiteColor = new Color(1, 1, 1, 1);

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

                    StartCoroutine(ChangeColor(_whiteColor, _correctColor));
                    LoyihaBirManager.CorrectEvent.Invoke();
                    LoyihaBirManager.NextTask2(GraphicOrder);
                }
                else
                {
                    //_rectTransform.position = _originalPosition;
                    _rectTransform.DOMove(_originalPosition, 0.2f);
                    StartCoroutine(ChangeColor(_whiteColor, _errorColor));
                    LoyihaBirManager.WrongEvent.Invoke();
                }
            }
            else
            {
                //_rectTransform.position = _originalPosition;
                _rectTransform.DOMove(_originalPosition, 0.2f);
                StartCoroutine(ChangeColor(_whiteColor, _errorColor));
                LoyihaBirManager.WrongEvent.Invoke();
            }
            
        }

        IEnumerator SetInitialThings()
        {
            _imageObj = GetComponent<Image>();
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _originalPosition = _rectTransform.anchoredPosition;
            yield return new WaitForSeconds(0.5f);
            if (AnswerObject != null)
            {
                _targetObject = AnswerObject.transform.GetChild(0).gameObject;
            }            
        }

        IEnumerator ChangeColor(Color initialColor, Color eventColor)
        {
            _imageObj.DOColor(eventColor, 0.1f);
            yield return new WaitForSeconds(0.5f);
            _imageObj.DOColor(initialColor, 0.5f);
        }

    }
}
