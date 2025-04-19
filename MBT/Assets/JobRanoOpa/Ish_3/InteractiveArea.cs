using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LoyihaIshiUch
{
    public class InteractiveArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private SpriteRenderer _spriteRenderer;
        private Color _originalColor;
        public Color HoverColor = Color.cyan;


        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalColor = _spriteRenderer.color;
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            _spriteRenderer.color = HoverColor;
            //Debug.Log($"{gameObject.name} ustiga kirdi!");
            // Rangni yoki animatsiyani o'zgartiring
        }


        public void OnPointerExit(PointerEventData eventData)
        {
            _spriteRenderer.color = _originalColor;
            //Debug.Log($"{gameObject.name} ustidan chiqdi!");
            // Avvalgi holatga qaytaring
        }


    }
}
