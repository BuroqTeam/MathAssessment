using UnityEngine;

namespace LoyihaIshi
{
    public class DragOnXAxis : MonoBehaviour
    {
        public LineRenderer Linerenederer;
        public Transform TetaObject;
        private float xLeft = -6f; // Minimum X value
        private float xRight = 2f; // Maximum X value
        private bool isDragging = false;
        private float offsetX;

        void Update()
        {
            if (isDragging)
            {   // Get the mouse position in world space
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = transform.position.z; // Keep the same Z position

                float newX = mousePosition.x + offsetX;
                // Clamp the X position to stay within the defined range
                newX = Mathf.Clamp(newX, xLeft, xRight);

                transform.position = new Vector3(newX/*mousePosition.x + offsetX*/, transform.position.y, transform.position.z);
                UpdateLinePos(newX);
            }
        }

        private void OnMouseDown()
        {
            // Start dragging and calculate the offset
            isDragging = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offsetX = transform.position.x - mousePosition.x;
        }

        private void OnMouseUp()
        {
            // Stop dragging
            isDragging = false;
        }

        private void UpdateLinePos(float flo)
        {
            Vector3 vec3 = Linerenederer.GetPosition(0);
            vec3.x = flo + 0.2f;
            Linerenederer.SetPosition(0, vec3);
            UpdateCornerPosition();
        }

        private void UpdateCornerPosition()
        {
            Vector3 pointAPosition = Linerenederer.GetPosition(0);
            float xpos = Linerenederer.GetPosition(1).x;
            float ypos = (Linerenederer.GetPosition(2).y + Linerenederer.GetPosition(1).y) / 2;
            Vector3 pointBPosition = new Vector2(xpos, ypos);
            // Calculate the new position for the corner object
            TetaObject.position = pointAPosition + (2f / 7f) * (pointBPosition - pointAPosition);
        }

    }
}
