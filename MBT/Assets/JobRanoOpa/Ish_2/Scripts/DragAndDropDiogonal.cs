using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LoyihaIshi
{
    public class DragAndDropDiogonal : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public CinemaLine Cinemaline;
        public Transform FirstChair;
        public Transform LastChair;

        [Header("Chair Setup")]
        public Transform[] Seats;           // Array of chair positions

        [SerializeField]
        private Vector3 _disVec;
        
        private Vector2 pointA;  // Start point of the line
        private Vector2 pointB;  // End point of the line

        private Vector2 lineDirection;
        private Vector2 offset;          // Offset between mouse and object
        private Camera mainCamera;       // Main camera reference
        private float lineLength;        // Total length of the line
        private float initialProjection; // Initial projection distance
        private Transform closestChair;      // Closest chair reference
        private SpriteRenderer _spriteRenderer;
        private Transform _transform;
        private int _orderInLayer;
        

        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _transform = GetComponent<Transform>();
            _orderInLayer = _spriteRenderer.sortingOrder;
            _disVec = Seats[1].position - _transform.position;
            
            pointA = FirstChair.position - _disVec;
            pointB = LastChair.position - _disVec;
            mainCamera = Camera.main;
            // Calculate line direction and length
            lineDirection = (pointB - pointA).normalized;
            lineLength = Vector2.Distance(pointA, pointB);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            DraggingIsBegin(true);
            Vector2 worldMousePos = GetMouseWorldPosition(eventData);
            offset = (Vector2)transform.position - worldMousePos;

            // Project initial object position onto the line to get the starting point
            Vector2 projectedPoint = ProjectPointOnLine(transform.position);
            initialProjection = Vector2.Dot(projectedPoint - pointA, lineDirection);
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Get the mouse position in world coordinates
            Vector2 worldMousePos = GetMouseWorldPosition(eventData) + offset;
            // Project the mouse position onto the line
            Vector2 projectedPoint = ProjectPointOnLine(worldMousePos);
            float projectionDistance = Vector2.Dot(projectedPoint - pointA, lineDirection);
            // Clamp the position to stay within the bounds of pointA and pointB
            projectionDistance = Mathf.Clamp(projectionDistance, 0, lineLength);
            // Calculate the new position along the line
            Vector2 newPosition = pointA + projectionDistance * lineDirection;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            Cinemaline.DrawLine(transform.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Vector2 snappedPosition = ProjectPointOnLine(transform.position);
            transform.position = new Vector3(snappedPosition.x, snappedPosition.y, transform.position.z);
            
            SnapToNearestChair(); // Find the nearest chair and snap to it
            DraggingIsBegin(false);
        }

        private Vector2 GetMouseWorldPosition(PointerEventData eventData)
        {
            Vector3 mouseScreenPos = eventData.position;
            mouseScreenPos.z = Mathf.Abs(mainCamera.transform.position.z - transform.position.z);
            return mainCamera.ScreenToWorldPoint(mouseScreenPos);
        }

        private Vector2 ProjectPointOnLine(Vector2 point)
        {
            Vector2 pointToA = point - pointA;
            float projection = Vector2.Dot(pointToA, lineDirection);
            return pointA + Mathf.Clamp(projection, 0, lineLength) * lineDirection;
        }


        private void SnapToNearestChair()
        {
            float minDistance = float.MaxValue;
            // Find the closest chair
            foreach (Transform chair in Seats)
            {
                float distance = Vector3.Distance(transform.position, chair.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestChair = chair;
                }
            }
            // Snap the boy to the position near the closest chair while maintaining `disVec` offset
            if (closestChair != null)
            {
                Vector3 targetPosition = closestChair.position - _disVec;
                transform.position = targetPosition;
            }
            Cinemaline.DrawLine(transform.position);
        }

        /// <summary>
        /// Change order of SpriteRenderer and scale.
        /// </summary>
        /// <param name="isBegin"></param>
        void DraggingIsBegin(bool isBegin)
        {
            if (isBegin)
            {
                _spriteRenderer.sortingOrder = _orderInLayer + 2;
                _transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f);
            }
            else
            {
                _spriteRenderer.sortingOrder = _orderInLayer;
                _transform.DOScale(new Vector3(1, 1, 1), 0.1f);
            }
        }

        

    }
}
