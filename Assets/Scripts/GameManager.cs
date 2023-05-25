using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("卡片拖拽相关判定")]
    public GameObject NewGetCard;//现在拖拽的卡片

    [Header("Icon和Panel生成替换")]
    public List<GameObject> labelIconList = new List<GameObject>();
    public List<GameObject> labelPanelList = new List<GameObject>();

    [Header("作弊器相关")] 
    public Slider slider;
    public int cheatIndex;

    //[Header("标签Panel替换相关")]
    //public GameObject toActivate;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        
    }

    // 查找_currentLabelPanel在list labelPanelList中的序列号，返回序列号，命名为num
    public int GetThisIcon(GameObject _currentLabelPanel)
    {
        // 在labelPanelList中查找_currentLabelPanel的序列号
        int num = labelPanelList.IndexOf(_currentLabelPanel);
        return num;
    }
    // 查找Panel
    public GameObject GetThisPanel(GameObject _currentLabelIcon)
    {
        // 在labelPanelList中查找_currentLabelPanel的序列号
        int num = labelIconList.IndexOf(_currentLabelIcon);
        GameObject _currentLabelPanel = labelPanelList[num];
        return _currentLabelPanel;
    }

    // -------------------作弊和测试相关---------------------------
    public void Cheater()
    {
        Debug.Log("teleport to " + "level "+ cheatIndex);
        for (int i = 0; i < labelIconList.Count; i++)
        {
            labelIconList[i].SetActive(false);
            labelPanelList[i].SetActive(false);
        }
        labelIconList[cheatIndex].SetActive(true);
        labelPanelList[cheatIndex].SetActive(true);
    }
 
    // 获取目标slider的值，并打印出来
    public void GetSliderValue(Slider slider)
    {
        Debug.Log("Slider Value: " + slider.value);
        cheatIndex =  (int)slider.value;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    
    
}
