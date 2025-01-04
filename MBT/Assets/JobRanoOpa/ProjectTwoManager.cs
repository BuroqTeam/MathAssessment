using UnityEngine;
using UnityEngine.UI;

namespace LoyihaIshi
{
    public class ProjectTwoManager : MonoBehaviour
    {
        public GameObject[] ButtonObjects;
        Button[] _buttons = new Button[2];
        public GameObject[] Slides;
        [SerializeField] private int _index = 0;

        private void Awake()
        {
            _buttons[0] = ButtonObjects[0].GetComponent<Button>();
            _buttons[1] = ButtonObjects[1].GetComponent<Button>();

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
            if (_index == 2)
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

    }
}
