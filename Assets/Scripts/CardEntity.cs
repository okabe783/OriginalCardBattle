
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")] 
//カードデータそのもの
public class CardEntity : ScriptableObject
{
    public int AT;
    public int Hp;
    public int Cost;
    public Sprite icon;
}
