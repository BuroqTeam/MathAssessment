using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenUrl : MonoBehaviour
{
    public enum DeviceType { WebGL, Mobile, Desktop};
    public DeviceType CurrentDevice;

    public void Openurl()
    {
        switch (CurrentDevice)
        {
            case DeviceType.WebGL:
                OpenOnWebGL();
                break;
            case DeviceType.Mobile:
                OpenOnMobile();
                break;
            case DeviceType.Desktop:
                OpenOnDesktop();
                break;
            default:
                break;
        }
        
    }


    void OpenOnMobile()
    {
        Application.OpenURL("https://www.geogebra.org/graphing");
    }


    void OpenOnWebGL()
    {
        Application.ExternalEval("window.open('https://www.geogebra.org/graphing', 'www.geogebra.org/graphing')");
    }


    void OpenOnDesktop()
    {
        Application.OpenURL("www.geogebra.org/graphing");
    }


    private void OnMouseDown()
    {
        Debug.Log($"{gameObject.name} clicked!");
        // Qo‘shimcha amallarni shu yerga yozing
        Openurl();
    }

}
