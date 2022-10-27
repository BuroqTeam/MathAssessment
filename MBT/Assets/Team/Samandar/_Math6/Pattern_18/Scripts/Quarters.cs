using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quarters : MonoBehaviour
{
    public Pattern_18 Pattern_18;
    public void Chorak_1()
    {        
        Pattern_18.ChorakNumber = null;
        Pattern_18.ChorakNumber = 1.ToString();
        Pattern_18.Check();
    }
    public void Chorak_2()
    {
        Pattern_18.ChorakNumber = null;
        Pattern_18.ChorakNumber = 2.ToString();
        Pattern_18.Check();
    }
    public void Chorak_3()
    {
        Pattern_18.ChorakNumber = null;
        Pattern_18.ChorakNumber = 3.ToString();
        Pattern_18.Check();
    }
    public void Chorak_4()
    {
        Pattern_18.ChorakNumber = null;
        Pattern_18.ChorakNumber = 4.ToString();
        Pattern_18.Check();
    }
}
