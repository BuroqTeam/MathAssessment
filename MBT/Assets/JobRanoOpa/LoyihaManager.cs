using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoyihaIshi
{
    public class LoyihaManager : MonoBehaviour
    {
        public GameObject[] ProjectButtons;
        public GameObject ParentObj;


        void Start()
        {
            CheckSubject();
        }

        void CheckSubject()
        {
            if (ES3.Load<string>("Subject").Equals("Algebra") && ES3.Load<int>("ClassKey").Equals(10))
            {
                SwitchButtons();
            }
        }

        void SwitchButtons()
        {
            for (int i = 0; i < ProjectButtons.Length; i++)
            {
                ProjectButtons[i].SetActive(true);
                ProjectButtons[i].transform.SetParent(ParentObj.transform);
            }
        }

    }
}
