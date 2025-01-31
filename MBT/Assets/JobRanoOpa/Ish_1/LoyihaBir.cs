using DG.Tweening;
using System.Collections;
using System.Linq;
using TMPro;
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
        [Header("Parent task One")]
        public GameObject TaskOneParent;
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


        [Header("Task three objects")]
        public GameObject TaskThreeParent;
        public Image GraphicABC;
        public GameObject ParentStory;
        public Image QuestionImage;
        public TMP_Text QuestionOne;
        public TMP_Text QuestionTwo;
        public GameObject[] QuestionOneAnswers;
        public GameObject[] QuestionTwoAnswers;

        [Header("Question three objs")]
        public GameObject QuestionObj;
        public GameObject InputFieldObj;

        [Header("Task Four objects")]
        public GameObject TaskFourParent;
        public GameObject TaskFourPanel;

        private float _duration = 0.7f;
        private Color _errorColor = new Color(0.89f, 0.65f, 0.65f, 1);
        private Color _correctColor = new Color(0.76f, 0.92f, 0.81f, 1);
        private Color _whiteColor = new Color(1, 1, 1, 1);
        private bool _isTaskThreeFinished = false;


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
            _canvasWidth = CanvasObj.gameObject.GetComponent<RectTransform>().rect.width;
            RectStories.gameObject.SetActive(true);
            RectGraphics.gameObject.SetActive(true);

            TaskTwoPanel.SetActive(false);
            TaskTwoParent.SetActive(false);

            TaskThreeParent.SetActive(false);
            ParentStory.GetComponent<Image>().DOFade(0, 0);
            ParentStory.transform.GetChild(0).GetComponent<TMP_Text>().DOFade(0, 0);
            QuestionObj.SetActive(false);//++
            InputFieldObj.SetActive(false);//++
            GraphicABC.DOFade(0, 0);
            TaskThreeSetQuestions(0);

            TaskFourParent.SetActive(false);
            TaskFourPanel.SetActive(false);
            
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
        /// This metod responsible call Task Two and out Task One objects.
        /// </summary>
        public void NextTask2(int graphicOrder)
        {
            GraphicStatus[graphicOrder] = true;
            if (GraphicStatus.All(b => b))
            {
                StartCoroutine(OutTaskOneObjectsFromScene());
            }
        }

        
        IEnumerator OutTaskOneObjectsFromScene() // Out task one and set task two.
        {
            yield return new WaitForSeconds(1);
            TaskOneParent.GetComponent<RectTransform>().DOAnchorPosX(-_canvasWidth, _duration);
            //RectStories.DOAnchorPosX(_canvasWidth, _duration);
            //RectGraphics.DOAnchorPosX(_canvasWidth, _duration);
            //LeftButton.GetComponent<RectTransform>().DOAnchorPosX(_canvasWidth, _duration);
            //RightButton.GetComponent<RectTransform>().DOAnchorPosX(_canvasWidth, _duration);
            yield return new WaitForSeconds(1.0f);
            TaskTwoPanel.SetActive(true);
            TaskTwoParent.SetActive(true);
        }


        /// <summary>
        /// This method must called in "Yakunlash Button"
        /// </summary>
        public void NextTask3()
        {
            StartCoroutine(SettingTaskThree());
        }


        IEnumerator SettingTaskThree()
        {
            TaskThreeParent.gameObject.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            TaskTwoPanel.GetComponent<RectTransform>().DOAnchorPosX(-_canvasWidth, _duration);
            TaskTwoParent.GetComponent<RectTransform>().DOAnchorPosX(-_canvasWidth, _duration);
            yield return new WaitForSeconds(1);
            
            ParentStory.GetComponent<Image>().DOFade(1, _duration);
            yield return new WaitForSeconds(_duration / 2);
            ParentStory.transform.GetChild(0).GetComponent<TMP_Text>().DOFade(1, _duration);
            yield return new WaitForSeconds(2 * _duration);
            GraphicABC.DOFade(1, _duration);
            yield return new WaitForSeconds(_duration);
            TaskThreeSetQuestions(1);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionOrder">question order index</param>
        public void TaskThreeSetQuestions(int questionOrder)
        {
            switch (questionOrder)
            {
                case 0:
                    QuestionImage.DOFade(0, _duration);
                    QuestionOne.DOFade(0, _duration);
                    QuestionTwo.DOFade(0, _duration);
                    StartCoroutine(FadeObject(QuestionOneAnswers, 0, _duration));
                    StartCoroutine(FadeObject(QuestionTwoAnswers, 0, _duration));
                    break;
                case 1:
                    QuestionImage.DOFade(1, _duration);
                    QuestionOne.DOFade(1, _duration);
                    StartCoroutine(FadeObject(QuestionOneAnswers, 1, _duration));
                    break;
                case 2:
                    QuestionOne.DOFade(0, _duration);
                    QuestionTwo.DOFade(1, _duration);
                    StartCoroutine(FadeObject(QuestionOneAnswers, 0, _duration));
                    StartCoroutine(FadeObject(QuestionTwoAnswers, 1, _duration));
                    break;
                case 3:
                    QuestionImage.DOFade(0, _duration);
                    QuestionTwo.DOFade(0, _duration);
                    StartCoroutine(FadeObject(QuestionTwoAnswers, 0, _duration));
                    break;
                default:
                    break;
            }
        }

        IEnumerator FadeObject(GameObject[] objs, float fadeVal, float duration)
        {
            yield return new WaitForSeconds(duration);
            
            for (int i = 0; i < objs.Length; i++)
            {
                if (fadeVal == 0)
                {
                    objs[i].SetActive(false);
                }
                else
                {
                    objs[i].SetActive(true);
                }
                objs[i].GetComponent<Image>().DOFade(fadeVal, _duration);
                objs[i].transform.GetChild(0).GetComponent<TMP_Text>().DOFade(fadeVal, _duration);
            }
        }


        /// <summary>
        /// This metod called in button.
        /// </summary>
        /// <param name="imag"></param>
        public void CorrectAnimation(Image imag)
        {
            CorrectEvent.Invoke();
            imag.DOColor(_correctColor, 0.5f);
            StartCoroutine(ReturnInitialColor(imag));
            StartCoroutine(CallNextTask(imag, true));
        }


        public void WrongAnimation(Image imag)
        {
            WrongEvent.Invoke();
            imag.DOColor(_errorColor, 0.5f);
            StartCoroutine(ReturnInitialColor(imag));
        }

        
        IEnumerator CallNextTask(Image imag, bool isTrue)
        {
            yield return new WaitForSeconds(1.5f);
            if (_isTaskThreeFinished)
            {
                Debug.Log("TaskFour");
                // I add my code hear
                StartCoroutine(CallQuestionThree());
                //NextTask4();
            }
            else if (isTrue)
            {
                _isTaskThreeFinished = true;
                TaskThreeSetQuestions(2);
            }
        }

        /// <summary>
        /// This method call question three for Task two.
        /// </summary>
        /// <returns></returns>
        IEnumerator CallQuestionThree()
        {
            ParentStory.GetComponent<Image>().DOFade(0, _duration);
            ParentStory.transform.GetChild(0).GetComponent<TMP_Text>().DOFade(0, _duration);
            TaskThreeSetQuestions(3);
            yield return new WaitForSeconds(1);
            //ParentStory.SetActive(false);
            QuestionObj.SetActive(true);
            InputFieldObj.SetActive(true);
        }


        /// <summary>
        /// This method responsible for calling Task4.
        /// </summary>
        public void NextTask4()
        {
            StartCoroutine(SettingTaskFour());
        }


        IEnumerator SettingTaskFour()
        {
            yield return new WaitForSeconds(2.0f);
            TaskThreeParent.GetComponent<RectTransform>().DOAnchorPosX(_canvasWidth, _duration);
            yield return new WaitForSeconds(1.0f);
            TaskFourParent.SetActive(true);
            TaskFourPanel.SetActive(true);
        }


        IEnumerator ReturnInitialColor(Image imag)
        {
            yield return new WaitForSeconds(1.0f);
            imag.DOColor(_whiteColor, 0.5f);
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
