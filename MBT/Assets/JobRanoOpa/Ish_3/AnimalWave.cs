using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoyihaIshiUch
{
    public class AnimalWave : MonoBehaviour
    {
        public enum AnimalType { Rabbit, Lynx };
        public AnimalType CurrentType;

        public LineRenderer MyLineRenderer;
        public int points;
        public float amplitude;
        public float frequency;
        public Vector2 xLimits = new Vector2(0, 1);
        public float Xminus;
        public float Yminus;

        void Start()
        {
            //MyLineRenderer = GetComponent<LineRenderer>();
            //Draw();
        }


        void Update()
        {
            Draw();
        }

        void Draw()
        {
            float xStart = xLimits.x/*-2 * Mathf.PI*/;
            float Tau = 2 * Mathf.PI;
            float xFinish = xLimits.y/*Tau*/;

            MyLineRenderer.positionCount = points;
            for (int currentPoint = 0; currentPoint < points; currentPoint++)
            {
                float progress = (float)currentPoint / (points - 1);
                float x = Mathf.Lerp(xStart, xFinish, progress);
                float y;
                if (CurrentType == AnimalType.Rabbit)
                {
                    y = Mathf.Sin((x /*- Xminus*/) * frequency - Xminus) * amplitude - Yminus;
                }
                else
                {
                    y = - Mathf.Cos((x + 1) * frequency - Xminus) * amplitude - Yminus;
                }
                //float y = Mathf.Sin(x) * amplitude;
                MyLineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));
            }
        }



    }
}
