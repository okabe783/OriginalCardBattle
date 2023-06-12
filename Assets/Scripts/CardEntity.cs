using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")] 
//カードデータそのもの
public class CardEntity : ScriptableObject
{
    public int AT;
    public Sprite icon;

}
