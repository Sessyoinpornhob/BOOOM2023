using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LabelPanel : MonoBehaviour
{
    [Header("基础卡牌判定")]
    public GameObject cardBar; // 获取卡牌的判定区，每个Panel只需要一个
    
    [Header("文本相关")]
    public string labelPanelID; // 用于text判定
    public TextManager textManager;
    public GameObject textTarget; // 在LabelPanel上写入文本的地方
    [Header("打字机效果")]
    [Tooltip("单个字符的最大显示间隔")]
    public float MaxNextTime = 0.05f;//显示下一个字的冷却时间
    

    [Header("任务判定点配置")]
    [Tooltip("目前最多是5个")]
    public int cardJudgeCount; // 需要判定的次数
    // 这些需要手动配置
    public List<GameObject> cardJudge01 = new List<GameObject>();
    public List<GameObject> cardJudge02 = new List<GameObject>();
    public List<GameObject> cardJudge03 = new List<GameObject>();
    public List<GameObject> cardJudge04 = new List<GameObject>();
    public List<GameObject> cardJudge05 = new List<GameObject>();
    public List<List<GameObject>> cardJudges = new List<List<GameObject>>();
    
    [Header("游戏阶段判定")]
    public GameStageManager gameStageManager;
    public GameObject currentLabelIcon; // 匹配的LabelIcon

    [Header("图片生成设置")] 
    public Image targetImage;
    

    public void Start()
    {
        LabelPanelStart();
    }
    

    // 初始化每个LabelPanel中判定点的数量，对应的每个判定点cardJudge所需要的卡片在编辑器中指定
    public void LabelPanelStart()
    {
        cardJudges.Add(cardJudge01);
        cardJudges.Add(cardJudge02);
        cardJudges.Add(cardJudge03);
        cardJudges.Add(cardJudge04);
        cardJudges.Add(cardJudge05);
        //Debug.Log(cardJudges.Count);
        
        for (int i = 0; i < (5-cardJudgeCount); i++)
        {
            cardJudges.RemoveAt(cardJudges.Count-1);
        }
    }

    // 传入newGetCard，并与cardJudges表中首个list需求的card进行判定
    public void CardJudge(GameObject newGetCard)
    {

        newGetCard = GameManager.instance.NewGetCard;
        if (cardJudges[0] != null)
        {
            // newGetCard是否在cardJudge01(为例)中，如果在就删除表中对应元素
            if (cardJudges[0].IndexOf(newGetCard) != -1)
            {
                Debug.Log(newGetCard.name + " is Right");

                // -----------------------游戏内容更新--------------------------
                // 生成新的文本
                GetTextInTextManager(newGetCard,1);
                // 调用音效
                SoundManager.instance.GetIntoAudio();
                // 生成图片 能用 下面是要改Sprite
                var spriteString = GetSpriteString(newGetCard);
                if (spriteString != "null")
                {
                    InstantiateNewImage(targetImage.gameObject, spriteString);
                }
                
                // -----------------------游戏机制更新--------------------------
                cardJudges[0].RemoveAt(cardJudges[0].IndexOf(newGetCard));


                // 当cardJudge01列表里没东西了以后视为成功
                if (cardJudges[0].Count == 0)
                {

                    // -----------------------游戏内容更新--------------------------
                    // 在一个CardJudge完成后（位置2）输出文本
                    GetTextInTextManager(newGetCard,2);
                    
                    // -----------------------游戏机制更新--------------------------
                    if (cardJudges.Count != 1)
                    {
                        cardJudges.RemoveAt(0);
                        //Debug.Log("删除首个判定点");
                    }
                    else
                    {
                        // 这个地方算是判定完成了整个标签的内容
                        // 下一步包括active新的LabelIcon，这个函数的实现最好交给gamemanager。
                        Debug.Log("本标签全部任务完成->进行下一步");
                        
                        gameStageManager.StageUpdate(currentLabelIcon);
                        gameStageManager.StageCheck();

                    }
                }
            }
        }
        Debug.Log("完成了一次判定");
    }


    /*---------------------------图片相关-------------------------------*/
    // 获取图片在CSV中的字符串
    public string GetSpriteString(GameObject newGetCard)
    {
        string newGetCardID = newGetCard.GetComponent<Card>().cardID;
        // 做一个空检测，以防出现此处不需要插画改变的情况。
        string spriteString = textManager.TextSearch(newGetCardID, 2);

        //Debug.Log("spriteString = " + spriteString);
        return spriteString;// 这里有可能返回null
    }

    // 实例化Image，然后更换Sprite。找时间改到ImageManager里面去。
    public void InstantiateNewImage(GameObject refImage, string spriteString)
    {
        var instancedImage =  Instantiate(refImage,gameObject.transform);
        var instancedImageComponent = instancedImage.GetComponent<Image>();
        //Debug.Log("instancedImageComponent name = " + instancedImageComponent );
        ImageManager.instance.SwitchSprite(instancedImageComponent, spriteString);

    }


    /*-------------------------文本生成相关-----------------------------*/
    // 获取字符串和播放字符串，双条件判定也加在这里把。
    public void GetTextInTextManager(GameObject newGetCard, int mode)
    {
        string newGetCardID = newGetCard.GetComponent<Card>().cardID;
        string doubleCondition = textManager.TextSearch(newGetCardID, 3);
        
        // 在卡牌验证后（位置1）输出文本
        if (mode == 1)
        {
            if (doubleCondition == "null")
            {
                string labelPanelText01 = textManager.TextSearch(newGetCardID, 1);
                textTarget.GetComponent<Text>().text = labelPanelText01;
                
                labelPanelNewText = textManager.TextSearch(newGetCardID, 1);
                textTarget.GetComponent<Text>().text = "";
                TextNum = 0;
                IsWrite = true;
            }
        }
        // 在一个CardJudge完成后（位置2）输出文本
        else if (mode == 2)
        {
            if (doubleCondition == "Yes")
            {
                string labelPanelText01 = textManager.TextSearch(newGetCardID, 1);
                textTarget.GetComponent<Text>().text = labelPanelText01;
                
                labelPanelNewText = textManager.TextSearch(newGetCardID, 1);
                textTarget.GetComponent<Text>().text = "";
                TextNum = 0;
                IsWrite = true;
            }
        }

    }
    
    
    /*-----------------------打字机效果-------------------------------*/
    string labelPanelNewText;//记录现在用要显示的文本
    [Header("打字机效果")]
    public bool IsWrite;//现在是否在录入文字
    float NextTextNewTime;
    int TextNum;//正在使用文本上的第几个字

    public void Update()
    {
        if (IsWrite)
        {
            NextTextNewTime += Time.deltaTime;
            TextUseing();
        }
    }
    public void TextUseing()
    {
        if (NextTextNewTime>=MaxNextTime)
        {
            NextTextNewTime = 0;//时间重置
            TextNum++;
            if (TextNum== labelPanelNewText.IndexOf("\\"))
            {
                TextNum += 2;
                textTarget.GetComponent<Text>().text += "\n";
            }

            textTarget.GetComponent<Text>().text += labelPanelNewText[TextNum];
            if (TextNum >= labelPanelNewText.Length-1)
            {
                IsWrite = false;
                TextNum = 0;
            }
        }
    }

}
