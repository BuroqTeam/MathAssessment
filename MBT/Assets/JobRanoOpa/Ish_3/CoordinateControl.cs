using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoyihaIshiUch
{
    public class CoordinateControl : MonoBehaviour
    {
        public enum OrderOfCoordinate { Zero, One, Two, Three, Four, Five};
        public OrderOfCoordinate CurrentOrder;

        public GameObject[] InteractiveAreas;

        void Start()
        {
            SetCoordinate();
        }

        
        private void SetCoordinate()
        {
            switch (CurrentOrder)
            {
                case OrderOfCoordinate.Zero:
                    break;
                case OrderOfCoordinate.One:
                    InteractiveAreas[0].SetActive(true);
                    break;
                case OrderOfCoordinate.Two:
                    InteractiveAreas[1].SetActive(true);
                    break;
                case OrderOfCoordinate.Three:
                    InteractiveAreas[2].SetActive(true);
                    break;
                case OrderOfCoordinate.Four:
                    InteractiveAreas[3].SetActive(true);
                    break;
                case OrderOfCoordinate.Five:
                    InteractiveAreas[0].SetActive(true);
                    InteractiveAreas[1].SetActive(true);
                    InteractiveAreas[2].SetActive(true);
                    InteractiveAreas[3].SetActive(true);
                    break;
                default:
                    break;
            }
        }


        private void SwitchCordinate(int order)
        {
            if (order == 0)
            {
                
            }

        }


    }
}
