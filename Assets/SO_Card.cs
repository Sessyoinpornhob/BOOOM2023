using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class SO_Card : ScriptableObject
{
    // 创建资源菜单
    public string cardID;
    public Sprite frontSprite, rearSprite;
    public bool isNote = false;
    public int useCount = 0;
    
    
}
    

