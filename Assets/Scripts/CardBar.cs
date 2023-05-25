using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBar : MonoBehaviour, IPointerEnterHandler
{
    public GameObject newGetCard;
    public LabelPanel LabelPanel;
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        
        newGetCard = GameManager.instance.NewGetCard;
        if (newGetCard != null)
        {
            Debug.Log("哥们拖卡片进来啦: " + newGetCard.name);
            LabelPanel.CardJudge(newGetCard);
        }
    }
    
}
