using UnityEngine;
using UnityEngine.EventSystems;

namespace LoyihaIshi
{
    public class BoyDragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public CinemaLine Cinemaline;
        private Vector3 offset;              // Offset between mouse and object position
        private Camera mainCamera;           // Reference to the main camera

        [Header("Chair Setup")]
        public Transform[] chairs;           // Array of chair positions
        private Vector3 disVec;              // Distance offset between boy and chair
        private Vector3 initialPosition;     // Initial position of the boy
        private Transform closestChair;      // Closest chair reference

        private float xLeft = -5.5f; // Minimum X value
        private float xRight = 4f; // Maximum X value

        private void Start()
        {
            disVec = transform.position - chairs[0].position;
            mainCamera = Camera.main;
            initialPosition = transform.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {   // Calculate offset between mouse position and boy's position
            offset = transform.position - GetMouseWorldPosition(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {   // Update the boy's position as the mouse is dragged
            Vector3 newPosition = GetMouseWorldPosition(eventData) + offset;
            newPosition = new Vector3(newPosition.x, initialPosition.y, newPosition.z);
            newPosition.x = Mathf.Clamp(newPosition.x, xLeft, xRight);
            transform.position = newPosition;
            Cinemaline.DrawLine(transform.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {   // Find the nearest chair and snap to it
            SnapToNearestChair();
        }

        private Vector3 GetMouseWorldPosition(PointerEventData eventData)
        {
            Vector3 mouseScreenPosition = eventData.position; // Mouse position in screen space
            mouseScreenPosition.z = Mathf.Abs(mainCamera.transform.position.z - transform.position.z);
            return mainCamera.ScreenToWorldPoint(mouseScreenPosition); // Convert to world position
        }

        private void SnapToNearestChair()
        {
            float minDistance = float.MaxValue;
            // Find the closest chair
            foreach (Transform chair in chairs)
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
                Vector3 targetPosition = closestChair.position + disVec;
                transform.position = targetPosition;
            }

            Cinemaline.DrawLine(transform.position);
        }
    }
}
