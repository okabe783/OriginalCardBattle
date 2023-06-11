using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]   //project��+��CardEntity����邱�Ƃ��ł���悤�ɂȂ�
//�J�[�h�f�[�^���̂���
public class CardEntity : ScriptableObject
{
    public string cardname;
    public int number;       
    public Sprite icon;
}
