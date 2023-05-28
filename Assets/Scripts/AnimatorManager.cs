using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 基本上是用协程实现的动画效果...
public class AnimatorManager : MonoBehaviour
{
    public static AnimatorManager instance;
    public float grayScale;

    [Header("其实是反向的")]
    public float switchSpeed;

    private Color _color;
    private SpriteRenderer _target;
    private Vector4 tempV4 = Vector4.one;

    [Header("背景")]
    public SpriteRenderer bg;
    
    [Header("卡牌列表")]
    public GameObject[] cardVistuals;
    


    public void Awake()
    {
        instance = this;
    }

    // 让背景变暗
    public void SwitchSrColorDark(SpriteRenderer target)
    {
        _color = target.color;
        _target = target;
        
        StartCoroutine(ChangeGrayScaleDown());
    }

    // 酱紫写协程太诡异了，得去看看商业框架...我感觉自己现阶段也看不了那些。
    // 再做几个东西再说吧。
    IEnumerator ChangeGrayScaleDown()
    {
        float x = _color.r;
        float y = _color.g;
        float z = _color.b;

        while (x > grayScale)
        {
            x -= 0.01f;
            y -= 0.01f;
            z -= 0.01f;
            tempV4.x = x;
            tempV4.y = y;
            tempV4.z = z;
            _target.color = tempV4;
            yield return new WaitForSeconds(0.01f * switchSpeed);
        }
    }
    
    // 点亮背景
    public void SwitchSrColorLight(SpriteRenderer target)
    {
        _color = target.color;
        _target = target;
        
        StartCoroutine(ChangeGrayScaleUp());
    }

    IEnumerator ChangeGrayScaleUp()
    {
        float x = _color.r;
        float y = _color.g;
        float z = _color.b;

        while (x < 1.0f)
        {
            x += 0.01f;
            y += 0.01f;
            z += 0.01f;
            tempV4.x = x;
            tempV4.y = y;
            tempV4.z = z;
            _target.color = tempV4;
            yield return new WaitForSeconds(0.01f * switchSpeed);
        }
    }
    
    // 让卡牌变暗
    public void SwitchCardsSrColorDark()
    {
        cardVistuals = GameObject.FindGameObjectsWithTag("CardSprite");
        StartCoroutine(ChangeCardsGrayScaleDown());
    }

    IEnumerator ChangeCardsGrayScaleDown()
    {
        Color defaultColor = Color.white;
        
        var alpha = 1f;

        while (alpha > grayScale)
        {
            alpha -= 0.01f;
            defaultColor = new Color(alpha, alpha, alpha, 1);
            
            // foreach只会在一帧内执行完毕。
            foreach (var card in cardVistuals)
            {
                card.GetComponent<SpriteRenderer>().color = defaultColor;
            }

            yield return null;
        }
    }
    
    // 所有卡牌变亮
    public void SwitchCardsSrColorLight()
    {
        cardVistuals = GameObject.FindGameObjectsWithTag("CardSprite");
        StartCoroutine(ChangeCardsGrayScaleUp());
    }
    IEnumerator ChangeCardsGrayScaleUp()
    {
        Color defaultColor = new Color(grayScale, grayScale, grayScale, 1.0f);
        
        var alpha = grayScale;

        while (alpha < 1f)
        {
            alpha += 0.01f;
            defaultColor = new Color(alpha, alpha, alpha, 1);
            
            // foreach只会在一帧内执行完毕。
            foreach (var card in cardVistuals)
            {
                card.GetComponent<SpriteRenderer>().color = defaultColor;
            }

            yield return null;
        }
    }
}
