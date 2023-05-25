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
    public GameObject currentLabelPanel;
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
    
    // 激活一个游戏对象，禁用另一个游戏对象的函数
    public void ActivateOneDeactivateAnother(GameObject toActivate, GameObject toDeactivate)
    {
        // 激活游戏对象
        toActivate.SetActive(true);
        // 禁用游戏对象
        toDeactivate.SetActive(false);
    }

    // 替换Icon和Panel
    public void SwitchIconAndPanel(GameObject _currentLabelPanel)
    {
        Debug.Log("_currentLabelPanel = " + _currentLabelPanel.name);
        // 获取其在列表中的位置
        int listIndex = GetThisPanelIcon(_currentLabelPanel);
        GameObject nextLabelPanel = labelPanelList[listIndex + 1];
        GameObject nextLabelIcon = labelIconList[listIndex + 1];
        GameObject _currentLabelIcon = labelIconList[listIndex];
        Debug.Log("nextLabelPanel = " + nextLabelPanel);
        
        // 禁用和激活
        ActivateOneDeactivateAnother(nextLabelIcon, _currentLabelIcon);
        ActivateOneDeactivateAnother(nextLabelPanel, _currentLabelPanel);
    }
    
    // ---------------------------这个地方建议重构-----------------------------------
    
    // 查找_currentLabelPanel在list labelPanelList中的序列号，返回序列号，命名为num
    public int GetThisPanelIcon(GameObject _currentLabelPanel)
    {
        // 在labelPanelList中查找_currentLabelPanel的序列号
        int num = labelPanelList.IndexOf(_currentLabelPanel);
        return num;
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
