using System.Collections;
using System.Collections.Generic;
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
        //public int 

        [Header("Target")]
        public GameObject correctTarget; // Assign the correct drop target in the Inspector

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _originalPosition = _rectTransform.anchoredPosition;
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
            if (!eventData.pointerEnter || eventData.pointerEnter.tag != "DropZone")
            {
                _rectTransform.position = _originalPosition;
            }
        }


    }
}
