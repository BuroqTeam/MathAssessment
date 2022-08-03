using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorCollection", menuName = "ScriptableObjects/ColorCollection", order = 6)]
public class ColorCollection : ScriptableObject
{
    public Color White;
    public Color Red;
    public Color Blue;
    public Color DarkBlue;
    public Color Green;
}
