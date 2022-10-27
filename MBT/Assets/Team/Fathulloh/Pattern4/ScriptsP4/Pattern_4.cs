using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_4 : GeneralTest
{    
    
    public GameEvent FinishEvent;
    //public TextAsset CurrentJsonText;   //-
    private TextAsset _currentJsonText;
    public SpriteCollectionSO spriteCOllectionSO;
    public GameObject PicturePrefab;    

    public List<GameObject> MainObjs;
    public GameObject ParentComparisonPrefab;

    public List<GameObject> ComparisonObjects;
    Data_4 Pattern_4Obj = new();
    float yDistance, xDistance;

    public string Statement1, Statement2, ImagePath1, ImagePath2;          
    Sprite spriteOfImage;
    public int totalFullAns, totalCorrectAns;

    public List<Vector3> PosLongPhone, PosSmallLongPhone, PosPhone, PosTablet;

    public bool CurrentAnswerStatus;
    bool _isTrue = true;

    private void OnEnable()
    {
        //if (ES3.Load<bool>("Pattern_4_Check"))        
        //    //ActiveNext.Raise();        
        //else
        //    //DeactiveNext.Raise();

        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;                        
            ReadFromJson();
        }

        DisplayQuestion(Pattern_4Obj.title);
    }



    //private void Awake()    // takrorlash 30-39, II-bob 30-39, III-bob 20-29, VI-bob 20-29, VII-bob 30-39
    //{
    //    //TestManager.Instance.PassToNextClicked += Check;//+
    //    //int ranNum = Random.Range(30, 39);
    //    
    //    //Mbt.SaveJsonPath("Pattern_4", 0, ranNum /*39*/);
    //    //ES3.Save<string>("LanguageKey", "Uzb");
    //    //ES3.Save<int>("ClassKey", 6);
    //    //ReadFromJson();
    //}


    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }


    void ReadFromJson()
    {
        //var jsonObj = JObject.Parse(CurrentJsonText.text);
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_4");
        Pattern_4Obj = jo.ToObject<Data_4>();
        
        CreatePrefabs();
    }


    void CreatePrefabs()
    {        
        for (int i = 0; i < Pattern_4Obj.statements.Count; i++) // o'ng tomondagi 2 ta rasmli prefabni yasab beradigan kod.
        {
            string str = Pattern_4Obj.statements[i].image;
            spriteOfImage = GetDesiredSprite(str, spriteCOllectionSO);
            GameObject obj = Instantiate(PicturePrefab, transform);
            //Debug.Log(spriteOfImage.name);
            obj.transform.GetChild(1).GetComponent<Image>().sprite = spriteOfImage;
            Vector2 newSize = new(spriteOfImage.texture.width / 5 * 3, spriteOfImage.texture.height / 5 * 3);   // spritening 80% ga moslab oladi.  
            obj.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = newSize; 
            
            obj.transform.GetChild(0).GetComponent<TMP_Text>().text = Pattern_4Obj.statements[i].statement;
            Vector2 newSizeText = obj.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
            obj.transform.GetChild(0).transform.localPosition = new Vector3(0, newSize.y/2 + newSizeText.y/2, 0);
            //obj.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(newSize.x, newSizeText.y);//+
            //Vector3 oldPos = obj.transform.localPosition;
            DeviceDetector(Screen.width, Screen.height, obj, i);           
        }
                        
        xDistance = MainObjs[1].transform.localPosition.x - MainObjs[0].transform.localPosition.x;
        yDistance = xDistance - MainObjs[0].GetComponent<RectTransform>().rect.width + MainObjs[0].GetComponent<RectTransform>().rect.height;
                
        for (int i = 0; i < Pattern_4Obj.options.Count; i++)
        {            
            GameObject obj = Instantiate(ParentComparisonPrefab, this.transform);
            Vector3 oldPos = obj.transform.localPosition;            
            obj.transform.localPosition = new Vector3(oldPos.x, oldPos.y -yDistance * (i), oldPos.z);
            
            ComparisonObjects.Add(obj);
        }
        WriteToPrefab();
    }

    
    
    public void DeviceDetector(float width, float height, GameObject obj, int i)
    {            // ushbu kod deviceni ni tekshirib beradi. Bazi o'yin obyektlari devicega qarab o'z pozitsiyasini o'zgartiradi.
        if (width / height > 2)        {
            //"Long phone"
            obj.GetComponent<RectTransform>().anchoredPosition = PosLongPhone[i];
        }
        else if (width / height == 2)   // Samandarning telini o'lchamiga qarab olindi.
        {
            //Debug.Log("PosSmallLongPhone");
            obj.GetComponent<RectTransform>().anchoredPosition = PosSmallLongPhone[i];
        }
        else if (width / height > 1.5f)        {
            //"Phone"
            obj.GetComponent<RectTransform>().anchoredPosition = PosPhone[i];
        }
        else if (width / height < 1.5f)        {
            //"Tablet"
            obj.GetComponent<RectTransform>().anchoredPosition = PosTablet[i];
        }
    }


    void WriteToPrefab()        //Data_4 dagi malumotlarni yozib beruvchi metod.
    {
        for (int i = 0; i < Pattern_4Obj.statements.Count; i++) // Ushbu for Kok rectanglelarni ichiga yozishga yordam beradi.
        {
            if (i == 0)            {
                MainObjs[0].transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_4Obj.statements[i].statement;
                Statement1 = Pattern_4Obj.statements[i].statement;
                ImagePath1 = Pattern_4Obj.statements[i].image;
            }
            else if (i == 1)            {
                MainObjs[2].transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_4Obj.statements[i].statement;
                Statement2 = Pattern_4Obj.statements[i].statement;
                ImagePath2 = Pattern_4Obj.statements[i].image;
            }
        }

        for (int i = 0; i<Pattern_4Obj.options.Count; i++) //Taqqoslanishi kerak bo'lgan obyektlarni ichiga yozadi.       
        {
            ComparisonObjects[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_4Obj.options[i].left;
            ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP4>().CorrectAnswer = Pattern_4Obj.options[i].sign.ToString();
            ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP4>().Pattern4 = this;
            ComparisonObjects[i].transform.GetChild(2).transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_4Obj.options[i].right;
        }
    }


    /// <summary>
    /// Sprite nomiga qarab sprite tanlab beruvchi method.
    /// </summary>
    /// <param name="spriteAddress">SpriteAdresi</param>
    /// <param name="spriteCollectionSO">Spritelar yig'ilgan Skriptbl Object</param>
    /// <returns></returns>
    public static Sprite GetDesiredSprite(string spriteAddress, SpriteCollectionSO spriteCollectionSO)
    {
        string[] splitedGroup = spriteAddress.Split("\\");
        string spriteName = splitedGroup[splitedGroup.Length - 1];
        splitedGroup = spriteName.Split(".");
        spriteName = splitedGroup[0];

        var desiredSprite = spriteCollectionSO.spriteGroup.Find(item => item.name == spriteName);
        return desiredSprite;
    }


    public void Check()
    {        
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");

        if (CurrentAnswerStatus)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            //Debug.Log("Correct");
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            //Debug.Log("Wrong");
        }
        ES3.Save("ResultList", currentList);
        
        //ES3.Save<bool>("Pattern_4_Check", true);
        //ActivateNext();
    }


    //void ActivateNext()
    //{
    //    int index = TestManager.Instance.ActivePatterns.FindIndex(o => o == gameObject);
    //    index++;
    //    TestManager.Instance.ActivePatterns[index].SetActive(true);
    //    gameObject.SetActive(false);
    //}


    int correctCount;
    public void CheckAllAnswers()
    {
        PatternButtonBlue();

        totalFullAns = 0;
        totalCorrectAns = 0;
        int n = Pattern_4Obj.options.Count;
        
        for (int i = 0; i < n; i++)
        {
            string currentAnswer = ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP4>().CurrentAnswer;
            string correctAnswer = ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP4>().CorrectAnswer;
            if (currentAnswer != null)            
                totalFullAns++;
            if (correctAnswer == currentAnswer)            
                totalCorrectAns++;            
        }

        if ((totalCorrectAns == n) && (totalFullAns == n))
        {
            CurrentAnswerStatus = true;
        }                    
        else if (totalFullAns == n)
        {
            CurrentAnswerStatus = false;
        }


        correctCount = 0;
        for (int i = 0; i < Pattern_4Obj.options.Count; i++)
        {
            string currentAnswer = ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP4>().CurrentAnswer;
            if (currentAnswer.Length == 1)
            {
                correctCount++;
            }
        }

        if (correctCount == Pattern_4Obj.options.Count)
        {
            //if (TestManager.Instance.CheckIsLast())            
            //    FinishEvent.Raise();            
            //else            
            //    //ActiveNext.Raise();
            //ES3.Save<bool>("Pattern_4_Check", true);
        }
        else
        {
            //DeactiveNext.Raise();            
            //ES3.Save<bool>("Pattern_4_Check", false);          
        }

    }


    void PatternButtonBlue()
    {        
        int fullDropDowns = 0;
        for (int i = 0; i < ComparisonObjects.Count; i++)
        {
            int currentAnswerLength = ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP4>().CurrentAnswer.Length;
            string currentAnswerStr = ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP4>().CurrentAnswer;
            
            if ((currentAnswerLength == 1) && (currentAnswerStr != ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP4>().InitialStr))            
                fullDropDowns++;            
        }

        if (fullDropDowns > 0)
        {
            GetComponent<Pattern>().IsEdited = true;
            TestManager.Instance.CheckAllIsDone();
        }            
        else
        {
            GetComponent<Pattern>().IsEdited = false;
            TestManager.Instance.CheckAllIsDone();
        }            
    }


}

[SerializeField]
public class Data_4
{
    public string title;
    public List<Statement_4> statements = new();
    public List<Option_4> options = new();
}

[SerializeField]
public class Statement_4
{
    public string statement;
    public string image;
}

[SerializeField]
public class Option_4
{
    public string left;
    public char sign;
    public string right;
}


/*
  //int ranNum = Random.Range(20, 29);
  //Mbt.SaveJsonPath("Pattern_4", 6, ranNum );
//ES3.Save<string>("LanguageKey", "Uzb");
//ES3.Save<int>("ClassKey", 6);

//CurrentDataBase.DataBase.Clear();
//CurrentJsonText = Mbt.GetDesiredData(CurrentDataBase);
*/