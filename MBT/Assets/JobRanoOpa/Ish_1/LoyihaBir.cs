using DG.Tweening;
using System.Collections;
using System.Linq;
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
        
        [HideInInspector] public bool[] GraphicStatus = new bool[4] { false, false, false, false };

        public GameObject CanvasObj;
        public RectTransform RectStories;
        public RectTransform RectGraphics;
        public GameObject LeftButton;
        public GameObject RightButton;
        public GameObject TaskTwoPanel;
        public GameObject TaskTwoParent;
        private float _canvasWidth;

        public UnityEvent CorrectEvent;
        public UnityEvent WrongEvent;

        void Start()
        {
            ShuffleSprites();
            SetInitialTasks();
            Invoke("SetGraphics", 0.05f);
            
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


        void SetInitialTasks()
        {
            RectStories.gameObject.SetActive(true);
            RectGraphics.gameObject.SetActive(true);

            TaskTwoPanel.SetActive(false);
            TaskTwoParent.SetActive(false);
        }


        void SetGraphics()
        {
            for (int i = 0; i < GraphicObjects.Length; i++)
            {
                string spriteName = GraphicSprites[i].name;
                int indexOfStory = System.Int32.Parse(spriteName[0].ToString());
                GraphicObjects[i].GetComponent<Image>().sprite = GraphicSprites[i];
                GraphicObjects[i].GetComponent<GraphicDragAndDrop>().LoyihaBirManager = this;
                if (indexOfStory == 1 || indexOfStory == 2 || indexOfStory == 3)
                {
                    GraphicObjects[i].GetComponent<GraphicDragAndDrop>().AnswerObject = Stories[indexOfStory - 1];
                    GraphicObjects[i].GetComponent<GraphicDragAndDrop>().GraphicOrder = i;
                }
                else
                {
                    GraphicStatus[i] = true;
                }
            }            
        }


        /// <summary>
        /// This metod responsible call next task.
        /// </summary>
        public void NextTask(int graphicOrder)
        {
            GraphicStatus[graphicOrder] = true;
            if (GraphicStatus.All(b => b))
            {
                Debug.Log("Next task work");
                StartCoroutine(OutObjectsFromScene());
            }
        }

        
        IEnumerator OutObjectsFromScene()
        {
            yield return new WaitForSeconds(1);
            _canvasWidth = CanvasObj.gameObject.GetComponent<RectTransform>().rect.width;
            RectStories.DOAnchorPosX(_canvasWidth, 0.7f);
            RectGraphics.DOAnchorPosX(-_canvasWidth, 0.7f);
            LeftButton.GetComponent<RectTransform>().DOAnchorPosX(-_canvasWidth, 0.7f);
            RightButton.GetComponent<RectTransform>().DOAnchorPosX(_canvasWidth, 0.7f);
            yield return new WaitForSeconds(1.0f);
            TaskTwoPanel.SetActive(true);
            TaskTwoParent.SetActive(true);
        }

        /// <summary>
        /// This is for leetcode
        /// </summary>
        /// <param name="candies"></param>
        /// <param name="num_people"></param>
        /// <returns></returns>
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
