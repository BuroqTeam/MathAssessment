using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_4 : TestManagerSample
{
    public DataBaseSO DataBase;
    public TextAsset CurrentJsonText;
    public SpriteCollectionSO spriteCOllectionSO;
    public GameObject PicturePrefab;
    

    public List<GameObject> MainObjs;
    public GameObject ParentComparisonPrefab;

    public List<GameObject> ComparisonObjects;
    Data_4 Pattern_4Obj = new Data_4();
    float yPos, xPos, yDistance, xDistance;

    public string Statement1, Statement2, ImagePath1, ImagePath2;       //
    public Sprite Sprite_Left, Sprite_Right;        //

    int totalFullAns, totalCorrectAns;
    Sprite spriteOfImage;

    private void Awake()
    {
        Mbt.SaveJsonPath("Pattern_4",7, 30);

        ES3.Save<string>("LanguageKey", "Uzb");

        ES3.Save<int>("ClassKey", 6);

        CurrentJsonText = Mbt.GetDesiredJSONData(DataBase);
        ReadFromJson();
    }



    private void OnEnable()
    {
        DisplayQuestion(Pattern_4Obj.title);
    }


    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr); // null        
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
        Debug.Log(Pattern_4Obj.statements.Count);
        for (int i = 0; i < Pattern_4Obj.statements.Count; i++)
        {
            string str = Pattern_4Obj.statements[i].image;
            spriteOfImage = GetDesiredSprite(str, spriteCOllectionSO);
            GameObject obj = Instantiate(PicturePrefab, transform);
            Debug.Log(spriteOfImage.texture.height + " " + spriteOfImage.texture.width);
            obj.transform.GetChild(1).GetComponent<Image>().sprite = spriteOfImage;

            obj.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(spriteOfImage.texture.width / 5 * 4, spriteOfImage.texture.height / 5 * 4);
            

            obj.transform.GetChild(0).GetComponent<TMP_Text>().text = Pattern_4Obj.statements[i].statement;
        }

        for (int i = 0; i < Pattern_4Obj.statements.Count; i++)
        {
            if (i == 0)            {
                MainObjs[0].transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_4Obj.statements[i].statement;
                Statement1 = Pattern_4Obj.statements[i].statement;//
                ImagePath1 = Pattern_4Obj.statements[i].image;//
            }
            else if (i == 1)    {
                MainObjs[2].transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_4Obj.statements[i].statement;
                Statement2 = Pattern_4Obj.statements[i].statement;//
                ImagePath2 = Pattern_4Obj.statements[i].image;//
            }
        }
                
        xDistance = MainObjs[1].transform.localPosition.x - MainObjs[0].transform.localPosition.x;
        yDistance = xDistance - MainObjs[0].GetComponent<RectTransform>().rect.width + MainObjs[0].GetComponent<RectTransform>().rect.height;
        float widthObj = MainObjs[2].transform.GetComponent<RectTransform>().rect.width;
        
        //Debug.Log("xDistance = " + xDistance + " yDistance = " + yDistance);

        for (int i = 0; i < Pattern_4Obj.options.Count; i++)
        {            
            GameObject obj = Instantiate(ParentComparisonPrefab, this.transform);
            Vector3 oldPos = obj.transform.localPosition;
            obj.transform.localPosition = new Vector3(oldPos.x, oldPos.y - yDistance * i, oldPos.z);
            ComparisonObjects.Add(obj);
        }

        for (int i = 0; i < Pattern_4Obj.options.Count; i++)        
        {
            ComparisonObjects[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_4Obj.options[i].left;
            ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP4>().CorrectAnswer = Pattern_4Obj.options[i].sign.ToString();
            ComparisonObjects[i].transform.GetChild(2).transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_4Obj.options[i].right;
        }

        Debug.Log("SpriteLeft width = " + Sprite_Left.texture.width + " SpriteLeft height = " + Sprite_Left.texture.height);
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
        Debug.Log(spriteName);
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

        if (totalCorrectAns == n)
        {
            Debug.Log("Everything is true.");
        }
        else if (totalFullAns == n)
        {
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