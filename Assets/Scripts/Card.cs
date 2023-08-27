using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
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
    public bool canHover = true;
    private float _grayScale;

    private void Start()
    {
        audioPlayCount = 1;
        canUse = false;
        canHover = true;
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

    // Hover 亮，但是在全场亮度暗的情况下
    public void OnMouseEnter()
    {
        if (gameObject.GetComponent<FlipCard>().canFlipCpunt == 0)
        {
            //Debug.Log("IN!");
            // get all child gameobjects' spriteRenderer color alpha and check if equals 1

            foreach (Transform card in transform)
            {
                if (card.GetComponent<SpriteRenderer>().color.r < 1f)
                {
                    StartCoroutine(ChangeCardsGrayScaleUpHover());
                }

            }
            
        }
    }
    
    // hover 变亮
    IEnumerator ChangeCardsGrayScaleUpHover()
    {
        _grayScale = AnimatorManager.instance.grayScale;
        Color defaultColor = new Color(_grayScale, _grayScale, _grayScale, 1.0f);

        while (_grayScale < 1f)
        {
            _grayScale += 0.1f;
            defaultColor = new Color(_grayScale, _grayScale, _grayScale, 1);
            
            // foreach只会在一帧内执行完毕。
            foreach (Transform card in transform)
            {
                card.GetComponent<SpriteRenderer>().color = defaultColor;
            }

            yield return null;
        }
    }

    public void OnMouseExit()
    {
        if (AnimatorManager.instance.isSceneLight == false && gameObject.GetComponent<FlipCard>().canFlipCpunt == 0)
        {
            // 判断 canFlipCpunt
            StartCoroutine(ChangeCardsGrayScaleDownHover());
        }
        
    }
    IEnumerator ChangeCardsGrayScaleDownHover()
    {
        _grayScale = AnimatorManager.instance.grayScale;
        Color defaultColor = new Color(1, 1, 1, 1.0f);

        var temp = 1f;

        while (_grayScale < temp)
        {
            temp -= 0.1f;
            defaultColor = new Color(temp, temp, temp, 1);
            
            // foreach只会在一帧内执行完毕。
            foreach (Transform card in transform)
            {
                card.GetComponent<SpriteRenderer>().color = defaultColor;
            }

            yield return null;
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