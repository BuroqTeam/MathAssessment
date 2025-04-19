using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoyihaIshiUch
{
    /// <summary>
    /// keraksiz script. O'chirib yuborish mumkin.
    /// </summary>
    public class SineWave : MonoBehaviour
    {
        public LineRenderer MyLineRenderer;
        public int points;
        public int amplitude;
        public float frequency;
        public Vector2 xLimits = new Vector2(0, 1);

        void Start()
        {
            MyLineRenderer = GetComponent<LineRenderer>();
            //Draw();
        }

        
        void Update()
        {
            Draw();
        }


        void Draw()
        {
            float xStart = xLimits.x;
            float Tau = 2 * Mathf.PI;
            float xFinish = xLimits.y/*Tau*/;

            MyLineRenderer.positionCount = points;
            for (int currentPoint = 0; currentPoint < points; currentPoint++)
            {
                float progress = (float)currentPoint / (points - 1);
                float x = Mathf.Lerp(xStart, xFinish, progress);
                float y = Mathf.Sin(x * /*Tau **/ frequency) * amplitude;
                MyLineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));
            }
        }


    }
}
