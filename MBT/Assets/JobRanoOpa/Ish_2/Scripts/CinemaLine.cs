using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoyihaIshi
{
    public class CinemaLine : MonoBehaviour
    {
        public Transform SittingBoy;
        private LineRenderer lineRenderer;
        private Vector3 distanceVec;
        public Transform TetaObject;
        Vector2 posOne;
        Vector2 posTwo;
        Vector2 posThree;
        Vector2 posMiddle;

        void Start()
        {
            lineRenderer = gameObject.GetComponent<LineRenderer>();
            distanceVec = SittingBoy.position - lineRenderer.GetPosition(1);
            SetMiddlePos();
        }

        public void DrawLine(Vector3 pos)
        {
            Vector3 newPos = pos - distanceVec;
            lineRenderer.SetPosition(1, newPos);
            UpdateTetaCornerPos();
        }

        void SetMiddlePos()
        {
            posOne = lineRenderer.GetPosition(0);
            posThree = lineRenderer.GetPosition(2);
            posMiddle = (posOne + posThree) / 2;
            //Debug.Log("posMiddle = " + posMiddle);
        }
        
        void UpdateTetaCornerPos()
        {
            posTwo = lineRenderer.GetPosition(1);
            float xPos = posTwo.x + (1f / 4f) * (posMiddle.x - posTwo.x);
            float yPos = posTwo.y + (1f / 5f) * (posMiddle.y - posTwo.y);
            TetaObject.position = new Vector2(xPos, yPos);
        }

    }
}
