using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestGroup : MonoBehaviour
{
    public TMP_Text NumberTxt;
    public TMP_Text PercentageTxt;
    public Image RadilaSlider;
    public float RadialSliderValue;
    public ColorCollectionSO colorSO;

    public TestGroupRaw RawTestGroup = new TestGroupRaw();
    Button button;

    void Start()
    {
        RadilaSlider.color = colorSO.Blue;
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        ES3.Save<int>("TestGroup", int.Parse(RawTestGroup.number));       
        GetComponent<SceneManager>().LoadLocalScene();
    }

    public void UpdateInfo()
    {      
        NumberTxt.text = RawTestGroup.number;
        PercentageTxt.text = RadialSliderValue.ToString() + "%";
        RadilaSlider.fillAmount = RadialSliderValue / 100;
    }




}


[SerializeField]
public class TestGroupRaw
{
    public string number;
   


}
