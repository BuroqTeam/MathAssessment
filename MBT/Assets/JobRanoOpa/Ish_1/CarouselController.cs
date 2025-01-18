using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LoyihaIshiBir
{
    public class CarouselController : MonoBehaviour
    {
        public GameObject parentObj; // ParentObj (Canvas ichida joylashgan)
        public Button leftButton;    // Left button
        public Button rightButton;   // Right button
        public float moveSpeed = 500f; // Harakat tezligi (pixellar/soniya)
        [HideInInspector] public float spacing = 200f;

        private RectTransform[] children;
        private int currentIndex = 0; // Hozirda ekranda ko'rinib turgan obyektning indeksi
        private bool isMoving = false;

        float canvasWidth;
        float childWidth;

        void Start()
        {
            children = new RectTransform[parentObj.transform.childCount];
            for (int i = 0; i < children.Length; i++)
            {
                children[i] = parentObj.transform.GetChild(i).GetComponent<RectTransform>();
            }

            // Child obyektlarni joylashtirish
            PositionChildren();

            // Dastlabki tugmalar holatini yangilash
            UpdateButtonStates();
        }

        public void OnRightButtonClick()
        {
            if (isMoving || currentIndex >= children.Length - 1) return;

            StartCoroutine(MoveToIndex(currentIndex + 1));
        }

        public void OnLeftButtonClick()
        {
            if (isMoving || currentIndex <= 0) return;

            StartCoroutine(MoveToIndex(currentIndex - 1));
        }

        private IEnumerator MoveToIndex(int targetIndex)
        {
            isMoving = true;
            if (currentIndex < targetIndex)
            {
                for (int i = 0; i < children.Length; i++)
                {
                    float xfloat = children[i].anchoredPosition.x;
                    children[i].DOAnchorPosX((xfloat - canvasWidth / 2 - childWidth / 2), 1);
                }
            }
            else
            {
                for (int i = 0; i < children.Length; i++)
                {
                    float xfloat = children[i].anchoredPosition.x;
                    children[i].DOAnchorPosX((xfloat + canvasWidth / 2 + childWidth / 2), 1);
                }
            }
            yield return new WaitForSeconds(1);
            
            currentIndex = targetIndex;
            isMoving = false;
            // Tugmalar holatini yangilash
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            // Left button faolligini tekshirish
            leftButton.interactable = currentIndex > 0;

            // Right button faolligini tekshirish
            rightButton.interactable = currentIndex < children.Length - 1;
        }

        private void PositionChildren()
        {   // Canvas ning kengligini olish
            Canvas canvas = parentObj.GetComponentInParent<Canvas>();
            canvasWidth = canvas.GetComponent<RectTransform>().rect.width;
            childWidth = children[0].rect.width;

            // Ekran markazini hisoblash
            float centerX = 0f;
            float yPos = children[0].anchoredPosition.y;
            // Obyektlarni joylashtirish
            for (int i = 0; i < children.Length; i++)
            {
                float xPos = centerX + (canvasWidth / 2 + childWidth / 2) * i;
                //centerX = xPos;
                children[i].anchoredPosition = new Vector2(xPos, yPos); // Local positionni o'zgartirish
            }
        }

    }
}
