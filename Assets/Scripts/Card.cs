using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Card : MonoBehaviour
{
    public string cardID;
    public bool isNote; // 卡片是否自由
    public int useMath; // 卡片的使用次数 归零消失

    public CardBar targetCardBar;

    public void OnMouseDrag()//拖拽卡片
    {
        if (isNote==false)
        {
            GameManager.instance.NewGetCard = gameObject;
            Vector2 m_mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(m_mousePostion.x, m_mousePostion.y,-2);
            // 设置位置
            // 使得GameManager可以检测到此卡片的存在
        }
    }
    
    public void OnMouseUp()//放开卡片
    {
        if (targetCardBar != null)
        {
            targetCardBar.SendToCardJudge();
        }
        
        transform.position = new Vector3(transform.position.x, transform.position.y,-2);
        // 检测卡片正确以后，播放特效VFX
        //canJudgeInBar = false;
    }

}