using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LoyihaIshiBir
{
    /// <summary>
    /// Thhis script is responsible to manage Loyiha Ishi 1
    /// </summary>
    public class LoyihaBir : MonoBehaviour
    {
        [Header("Sprites of graphics")]
        public Sprite[] GraphicSprites = new Sprite[4];
        public GameObject[] GraphicObjects = new GameObject[4];

        [Header("Stories array")]
        public GameObject[] Stories = new GameObject[3];
        


        void Start()
        {
            ShuffleSprites();
            Invoke("SetGraphics", 0.2f);
        }

        void ShuffleSprites()
        {
            for (int i = GraphicSprites.Length - 1; i > 0; i--)
            {   // Tasodifiy indeks yaratamiz
                int randomIndex = Random.Range(0, i + 1);
                // Hozirgi element bilan tasodifiy tanlangan elementni almashtiramiz
                Sprite temp = GraphicSprites[i];
                GraphicSprites[i] = GraphicSprites[randomIndex];
                GraphicSprites[randomIndex] = temp;
            }
        }

        void SetGraphics()
        {
            for (int i = 0; i < GraphicObjects.Length; i++)
            {
                GraphicObjects[i].GetComponent<Image>().sprite = GraphicSprites[i];
            }
            
        }

    }
}
