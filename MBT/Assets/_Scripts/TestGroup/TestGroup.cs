using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestGroup : MonoBehaviour
{
    public TMP_Text NumberTxt;
    public Image RadilaSlider;

    public TestGroupRaw RawTestGroup = new TestGroupRaw();

   
    private void Awake()
    {
        
    }

    public void UpdateInfo()
    {      
        NumberTxt.text = RawTestGroup.number;
    }




}


[SerializeField]
public class TestGroupRaw
{
    public string number;
   


}
