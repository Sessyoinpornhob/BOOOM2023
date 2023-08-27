using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject newGetCard;
    public LabelPanel labelPanel;
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        
        newGetCard = GameManager.instance.NewGetCard;
        
        if (newGetCard != null)
        {
            newGetCard.GetComponent<Card>().targetCardBar = this;
            
            /*Debug.Log("哥们拖卡片进来啦: " + newGetCard.name);
            labelPanel.CardJudge(newGetCard);*/
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        newGetCard.GetComponent<Card>().targetCardBar = null;
    }

    // 由card在满足条件的情况下调用这个函数，执行检测，从而达到松手检测的效果
    public void SendToCardJudge()
    {
        labelPanel.CardJudge(newGetCard);
    }
}

