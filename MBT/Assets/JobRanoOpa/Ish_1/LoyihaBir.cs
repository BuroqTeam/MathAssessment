using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
        public UnityEvent CorrectEvent;
        public UnityEvent WrongEvent;

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
                string spriteName = GraphicSprites[i].name;
                /*System.Convert.ToInt32(spriteName[0].ToString())*/
                int indexOfStory = System.Int32.Parse(spriteName[0].ToString());
                GraphicObjects[i].GetComponent<Image>().sprite = GraphicSprites[i];
                
                if (indexOfStory < 4)
                {
                    GraphicObjects[i].GetComponent<GraphicDragAndDrop>().AnswerObject = Stories[indexOfStory - 1];
                }
            }
            
        }

        public int[] DistributeCandies(int candies, int num_people)
        {
            int initial = 0;
            int[] ans = new int[num_people];

            while (candies > 0)
            {
                for (int i = 0; i < num_people; i++)
                {
                    int curVal = initial + (i + 1);
                    if (candies >= curVal)
                    {
                        candies -= curVal;
                        ans[i] = ans[i] + curVal;
                        if (candies == 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        ans[i] = ans[i] + candies;
                        candies = 0;
                        break;
                    }
                }
                initial += num_people;
            }

            return ans;
        }

    }
}
