using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_4 : TestManagerSample
{
    public DataBaseSO[] DataBases;
    public DataBaseSO CurrentDataBase;
    public TextAsset CurrentJsonText;
    public SpriteCollectionSO spriteCOllectionSO;
    public GameObject PicturePrefab;    

    public List<GameObject> MainObjs;
    public GameObject ParentComparisonPrefab;

    public List<GameObject> ComparisonObjects;
    Data_4 Pattern_4Obj = new Data_4();
    float yDistance, xDistance;

    public string Statement1, Statement2, ImagePath1, ImagePath2;       //
    
    Sprite spriteOfImage;
    int totalFullAns, totalCorrectAns;

    public List<Vector3> PosLongPhone, PosPhone, PosTablet;

    private void FirstMethod()    // takrorlash 30-39, II-bob 30-39, III-bob 20-29, VI-bob 20-29, VII-bob 30-39
    {
        //string str0 = ES3.Load<string>("Subject");//+
        //if (ES3.Load<string>("Subject") == "Algebra")
        //{
        //    Debug.Log("Algebra");
        //    DataBase = DataBases[0];
        //}
        //else if (str0 == "Geometriya")
        //{
        //    Debug.Log("Geometriya");
        //    DataBase = DataBases[1];
        //}

        int ranNum = Random.Range(20, 29);
        Debug.Log("ranNum = " + ranNum);
        Mbt.SaveJsonPath("Pattern_4", 3, ranNum /*39*/);

        ES3.Save<string>("LanguageKey", "Uzb");

        ES3.Save<int>("ClassKey", 6);

        CurrentDataBase.DataBase.Clear();
        CurrentJsonText = Mbt.GetDesiredJSONData(CurrentDataBase);
        ReadFromJson();
    }



    private void OnEnable()
    {
        FirstMethod();

        DisplayQuestion(Pattern_4Obj.title);
    }


    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);        
    }



    void ReadFromJson()
    {
        var jsonObj = JObject.Parse(CurrentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_4");
        Pattern_4Obj = jo.ToObject<Data_4>();
        
        CreatePrefabs();
    }


    void CreatePrefabs()
    {
        
        for (int i = 0; i < Pattern_4Obj.statements.Count; i++)
        {
            string str = Pattern_4Obj.statements[i].image;
            spriteOfImage = GetDesiredSprite(str, spriteCOllectionSO);
            GameObject obj = Instantiate(PicturePrefab, transform);

            obj.transform.GetChild(1).GetComponent<Image>().sprite = spriteOfImage;
            Vector2 newSize = new Vector2(spriteOfImage.texture.width / 5 * 3, spriteOfImage.texture.height / 5 * 3);   // spritening 80% ga moslab oladi.  
            obj.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = newSize; 
            
            obj.transform.GetChild(0).GetComponent<TMP_Text>().text = Pattern_4Obj.statements[i].statement;
            Vector2 newSizeText = obj.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
            obj.transform.GetChild(0).transform.localPosition = new Vector3(0, newSize.y/2 + newSizeText.y/2, 0);
            //obj.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(newSize.x, newSizeText.y);//+

            Vector3 oldPos = obj.transform.localPosition;
            DeviceDetector(Screen.width, Screen.height, obj, i);
            
            //obj.transform.localPosition = new Vector3(oldPos.x, oldPos.y - newSize.y * i * 1.2f, oldPos.z);
            //Debug.Log("obj.transform.localPosition = " + obj.transform.localPosition + " transfor.position = " + obj.transform.position);
        }

                        
        xDistance = MainObjs[1].transform.localPosition.x - MainObjs[0].transform.localPosition.x;
        yDistance = xDistance - MainObjs[0].GetComponent<RectTransform>().rect.width + MainObjs[0].GetComponent<RectTransform>().rect.height;
        float widthObj = MainObjs[2].transform.GetComponent<RectTransform>().rect.width;
        //Debug.Log("xDistance = " + xDistance + " yDistance = " + yDistance);
        
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
        if (width / height >= 2)        {
            //Debug.Log("Long phone.");
            obj.GetComponent<RectTransform>().anchoredPosition = PosLongPhone[i];
        }
        else if (width / height > 1.5f)        {
            //Debug.Log("Phone");
            obj.GetComponent<RectTransform>().anchoredPosition = PosPhone[i];
        }
        else if (width / height < 1.5f)        {
            //Debug.Log("Tablet");
            obj.GetComponent<RectTransform>().anchoredPosition = PosTablet[i];
        }
    }


    void WriteToPrefab()        //Data_4 dagi malumotlarni yozib beruvchi metod.
    {
        for (int i = 0; i < Pattern_4Obj.statements.Count; i++) // Ushbu for Kok rectanglelarni ichiga yozishga yordam beradi.
        {
            if (i == 0)            {
                MainObjs[0].transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_4Obj.statements[i].statement;
                Statement1 = Pattern_4Obj.statements[i].statement;//
                ImagePath1 = Pattern_4Obj.statements[i].image;//
            }
            else if (i == 1)            {
                MainObjs[2].transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_4Obj.statements[i].statement;
                Statement2 = Pattern_4Obj.statements[i].statement;//
                ImagePath2 = Pattern_4Obj.statements[i].image;//
            }
        }


        for (int i = 0; i<Pattern_4Obj.options.Count; i++) //Taqqoslanishi kerak bo'lgan obyektlarni ichiga yozadi.       
        {
            ComparisonObjects[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_4Obj.options[i].left;
            ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP4>().CorrectAnswer = Pattern_4Obj.options[i].sign.ToString();
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
        //Debug.Log(spriteName);
        var desiredSprite = spriteCollectionSO.spriteGroup.Find(item => item.name == spriteName);
        return desiredSprite;
    }


    public void CheckAllAnswers()
    {
        int n = Pattern_4Obj.options.Count;
        
        for (int i = 0; i < n; i++)
        {
            totalFullAns = 0;
            totalCorrectAns = 0;
            string currentAnswer = ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP4>().CurrentAnswer;
            string correctAnswer = ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP4>().CorrectAnswer;
            if (currentAnswer != null)            
                totalFullAns++;
            if (correctAnswer == currentAnswer)            
                totalCorrectAns++;            
        }

        if (totalCorrectAns == n)        {
            Debug.Log("Everything is true.");
        }
        else if (totalFullAns == n)        {
            Debug.Log("Some thing is wrong.");
        }
    }

}

[SerializeField]
public class Data_4
{
    public string title;
    public List<Statement_4> statements = new List<Statement_4>();
    public List<Option_4> options = new List<Option_4>();
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