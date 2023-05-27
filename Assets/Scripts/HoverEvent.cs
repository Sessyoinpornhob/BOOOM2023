using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// later
// 并不是很清楚这玩意能不能用在非UI的GameObject上
// 算了先这样
public class HoverEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 cachedScale;
    
    void Start()
    {
        cachedScale = transform.localScale;
    }
    
    public void OnPointerEnter(PointerEventData eventData) {
 
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
 
    public void OnPointerExit(PointerEventData eventData) {
 
        transform.localScale = cachedScale;
    }
    
}
