using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSender : MonoBehaviour
{
    public static CardSender instance;
    
    public List<FlipCard> cardLevel00 = new List<FlipCard>();
    public List<FlipCard> cardLevel01 = new List<FlipCard>();
    public List<FlipCard> cardLevel02 = new List<FlipCard>();
    public List<FlipCard> cardLevel03 = new List<FlipCard>();
    public List<FlipCard> cardLevel04 = new List<FlipCard>();
    public List<FlipCard> cardLevel05 = new List<FlipCard>();

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        StartCoroutine(FlipMuBei());
    }
    
    // 先把墓碑搞出来
    IEnumerator FlipMuBei()
    {
        yield return new WaitForSeconds(1f);
        cardLevel00[0].StartFlip();
    }

    // 这个就是翻卡的函数，具体哪里翻哪些还是要从CSV读。
    public void FlipCards(string mode)
    {
        if(mode == "1")
        {
            for (int i = 0; i < cardLevel01.Count; i++)
            {
                cardLevel01[i].StartFlip();
            }
        }
        if(mode == "2")
        {
            for (int i = 0; i < cardLevel02.Count; i++)
            {
                cardLevel02[i].StartFlip();
            }
        }
        if(mode == "3")
        {
            for (int i = 0; i < cardLevel03.Count; i++)
            {
                cardLevel03[i].StartFlip();
            }
        }
        if(mode == "4")
        {
            for (int i = 0; i < cardLevel04.Count; i++)
            {
                cardLevel04[i].StartFlip();
            }
        }
        if(mode == "5")
        {
            for (int i = 0; i < cardLevel05.Count; i++)
            {
                cardLevel05[i].StartFlip();
            }
        }
    }

}
