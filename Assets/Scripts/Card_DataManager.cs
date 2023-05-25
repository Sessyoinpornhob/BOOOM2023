using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Card_DataManager : MonoBehaviour
{
    private GameManager gameManager;
    public SO_Card cardData;
    //[HideInInspector]public string cardName;
    //[HideInInspector]public string cardText;
    //[HideInInspector]public string finCardText; // 完成卡片之后的文本
    

    public void Start()
    {
        gameManager = GameManager.instance;
        GetComponent<SpriteRenderer>().sprite = cardData.frontSprite;
        GetComponent<Card>().cardID = cardData.cardID;
        
        // 找到GameManager 其实可以直接指定
    }

    //public void FlipCard()
    //{
    //    GetComponent<SpriteRenderer>().sprite = cardData.rearSprite;
    //}

    public void OnMouseDrag()//拖拽卡片
    {
        if (cardData.isNote==false)
        {
            gameManager.GetComponent<GameManager>().NewGetCard = gameObject;
            Vector2 m_mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(m_mousePostion.x, m_mousePostion.y,-2);
            // 设置位置
            // 使得GameManager可以检测到此卡片的存在
        }
    }
    
    public void OnMouseUp()//放开卡片
    {
        //Debug.Log("Drag ended!");
        transform.position = new Vector3(transform.position.x, transform.position.y,-1);
        // 检测卡片正确以后，播放特效VFX
    }

}