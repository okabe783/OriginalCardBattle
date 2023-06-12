using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]   //projectの+でCardEntityを作ることができるようになる
//カードデータそのもの
public class CardEntity : ScriptableObject
{
    public new string name;
    public int number;       
    public Sprite icon;
}
