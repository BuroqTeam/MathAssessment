using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LoyihaIshiBir
{
    public class ProjectOneManager : MonoBehaviour
    {
        public GameObject[] ButtonObjects;
        Button[] _buttons = new Button[2];
        public GameObject[] Slides;
        [SerializeField] private int _index;

        private void Awake()
        {
            _buttons[0] = ButtonObjects[0].GetComponent<Button>();
            _buttons[1] = ButtonObjects[1].GetComponent<Button>();

            //ActivateButtons(false);
            _index = 0/*Slides.Length*/;
            SetInitial(_index);
            _buttons[0].interactable = false;
        }

        public void NextToLeft()
        {
            _index--;
            SetInitial(_index);
            if (_index == 0)
            {
                _buttons[0].interactable = false;
            }
            _buttons[1].interactable = true;
        }

        public void NextToRight()
        {
            _index++;
            SetInitial(_index);
            if (_index == Slides.Length - 1)
            {
                _buttons[1].interactable = false;
            }
            _buttons[0].interactable = true;
        }

        void SetInitial(int ind)
        {
            for (int i = 0; i < Slides.Length; i++)
            {
                if (i == ind)
                {
                    Slides[i].SetActive(true);
                }
                else
                {
                    Slides[i].SetActive(false);
                }
            }
        }


        public void ActivateButtons(bool isTrue)
        {
            ButtonObjects[0].SetActive(isTrue);
            ButtonObjects[1].SetActive(isTrue);
            //SetToZero();
            SetInitial(_index);
        }

        
        public void SetToZero()
        {
            for (int i = 0; i < Slides.Length; i++)
            {
                Slides[i].GetComponent<RectTransform>().DOAnchorPosX(0, 0);
            }
        }
    }
}
