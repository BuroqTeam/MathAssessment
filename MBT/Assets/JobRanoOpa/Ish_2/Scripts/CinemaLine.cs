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

        void Start()
        {
            lineRenderer = gameObject.GetComponent<LineRenderer>();
            distanceVec = SittingBoy.position - lineRenderer.GetPosition(1);
        }

        public void DrawLine(Vector3 pos)
        {
            Vector3 newPos = pos - distanceVec;
            lineRenderer.SetPosition(1, newPos);
            UpdateTetaCornerPos();
        }

        public Transform TetaObject;
        void UpdateTetaCornerPos()
        {
            Vector2 posOne = lineRenderer.GetPosition(0);
            Vector2 posTwo = lineRenderer.GetPosition(0);
            Vector2 posThree = lineRenderer.GetPosition(0);
            Vector2 tetaPos = TetaObject.position;
            TetaObject.position = new Vector3(tetaPos.x, (posTwo.y + (posOne.y + posThree.y) / 2));
        }

    }
}
