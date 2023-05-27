using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Card : MonoBehaviour
{
    [Header("基础信息")]
    public string cardID;
    public bool canUse = true; // 卡片是否可用

    [Header("判定相关")]
    public CardBar targetCardBar;

    [Header("音频视效相关")] 
    public int audioPlayCount;

    private void Start()
    {
        audioPlayCount = 1;
        canUse = false;
    }

    public void OnMouseDrag()//拖拽卡片
    {
        if (canUse == true)
        {
            GameManager.instance.NewGetCard = gameObject;
            Vector2 m_mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(m_mousePostion.x, m_mousePostion.y,-2);
            // 设置位置
            // 使得GameManager可以检测到此卡片的存在

            // 拖拽卡牌的时候要发出声音吗？
            if (audioPlayCount > 0)
            {
                //SoundManager.instance.GetClickAudio();
                audioPlayCount--;
            }
        }
    }
    
    public void OnMouseUp()//放开卡片
    {
        if (targetCardBar != null)
        {
            targetCardBar.SendToCardJudge();
        }
        else
        {
            if (canUse)
            {
                SoundManager.instance.GetClickAudio();
            }
        }
        transform.position = new Vector3(transform.position.x, transform.position.y,-2);
        audioPlayCount = 1;
        // 检测卡片正确以后，播放特效VFX
    }

    public void DestorySelf()
    {
        StartCoroutine(WaitAnimater());
    }
    IEnumerator WaitAnimater()
    {
        // 等待的时间就在这写吧，感觉public出去会有问题
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

}