using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]   //projectの+でCardEntityを作ることができるようになる
//カードデータそのもの
public class CardEntity : ScriptableObject
{
    public string cardname;
    public int number;       
    public Sprite icon;
}
