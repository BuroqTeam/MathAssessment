using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LoyihaIshi
{
    public class DragAndDropDiogonal : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [Header("Line Definition")]
        public Vector2 pointA = new Vector2(-5f, 3f);  // Start point of the line
        public Vector2 pointB = new Vector2(2f, -1f);  // End point of the line

        void Start()
        {

        }

        public void OnBeginDrag(PointerEventData eventData)
        {   // Calculate offset between mouse position and boy's position
            //offset = transform.position - GetMouseWorldPosition(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {   // Update the boy's position as the mouse is dragged
            //Vector3 newPosition = GetMouseWorldPosition(eventData) + offset;
            //newPosition = new Vector3(newPosition.x, initialPosition.y, newPosition.z);
            //newPosition.x = Mathf.Clamp(newPosition.x, xLeft, xRight);
            //transform.position = newPosition;
            //Cinemaline.DrawLine(transform.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {   // Find the nearest chair and snap to it
            //SnapToNearestChair();
        }

        public int RemoveElement(int[] nums, int val)
        {
            int ans = 0;
            int leng = nums.Length;
            int q = leng - 1;
            List<int> lis = new List<int>();
            
            for (int i = 0; i < leng; i++)
            {
                if (nums[i] == val)
                {
                    ans++;
                    nums[i] = 51;
                }
                for (int j = leng - 1; j <= 0; j--)
                {
                    if (nums[j] != val)
                    {
                        nums[i] = nums[j];
                        nums[j] = val;
                        break;
                    }
                }
            }
            
            
            return ans;
        }

    }
}
