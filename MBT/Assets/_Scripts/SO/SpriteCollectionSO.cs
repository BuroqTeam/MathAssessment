using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteCollection", menuName = "ScriptableObjects/SpriteCollection", order = 5)]
public class SpriteCollectionSO : ScriptableObject
{
    public List<Sprite> spriteGroup = new List<Sprite>();



}
