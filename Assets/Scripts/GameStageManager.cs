using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 设计这个class是为了在Label和Game之间再增加一个层，便于各种情况下的控制。
public class GameStageManager : MonoBehaviour
{

    [Header("当前阶段")]
    public int stageNumCurrent = 1;
    
    [Header("测试用列表")]
    public List<GameObject> stage01 = new List<GameObject>();
    public List<GameObject> stage02 = new List<GameObject>();
    public List<GameObject> stage03 = new List<GameObject>();
    public List<List<GameObject>> stages = new List<List<GameObject>>();
    
    // 屎山增加了。
    [Header("存储用列表")]
    public List<GameObject> stage01Backup = new List<GameObject>();
    public List<GameObject> stage02Backup = new List<GameObject>();
    public List<GameObject> stage03Backup = new List<GameObject>();
    public List<List<GameObject>> stagesBackup = new List<List<GameObject>>();

    [Header("动画和音效相关")] public float waitingtime;

    
    void Start()
    {
        stages.Add(stage01);
        stages.Add(stage02);
        stages.Add(stage03);
        //Debug.Log("we have " + stages.Count + " stages");
        // 通过泛型列表查到当前stage的对应列表（和里面的GameObjects）
        //Debug.Log("we are in the stage " + stages[stageNumCurrent - 1]);
        BackupList();
    }

    // 将测试用列表存档，在后面读
    public void BackupList()
    {
        stagesBackup.Add(stage01Backup);
        stagesBackup.Add(stage02Backup);
        stagesBackup.Add(stage03Backup);
        Debug.Log(stagesBackup[0][0].name);
        //stagesBackup = DeepCopy(stages);
    }
    

    // 将已完成的某个Icon传递到此函数中，在对应的列表里删除东西
    public void StageUpdate(GameObject finishedIcon)
    {
        Debug.Log("finishedIcon is ----> " + finishedIcon.name);
        if (stages[stageNumCurrent - 1].IndexOf(finishedIcon) != -1)
        {
            stages[stageNumCurrent - 1].RemoveAt(stages[stageNumCurrent - 1].IndexOf(finishedIcon));
        }
    }
    
    // 检测本Stage是否完成
    // 整个判定的逻辑和卡牌在Panel中的判定基本上一样，为什么还要写一遍...
    public void StageCheck()
    {
        if (stages[stageNumCurrent - 1].Count == 0)
        {
            Debug.Log("本阶段标签都已完成");
            StageSwitchSFXVFX();
        }
    }

    
    // DisActive本阶段所有的Label，Active下个阶段所有的Label
    public void StageSwitchSFXVFX()
    {
        // 视觉和听觉效果
        waitingtime = SoundManager.instance.GetFinishEventAudio();// 放音乐，返回音效时长。
        StartCoroutine(StageWaitForSound());// 开始协程
        
    }
    
    // 协程，在waitingtime后，切换标签。
    IEnumerator StageWaitForSound()
    {
        yield return new WaitForSeconds(waitingtime);
        Debug.Log("waitingtime = "+ waitingtime);
        Debug.Log("musicFinished");
        // 在这个函数中写需要延迟调用的内容。
        StageSwitch();
    }

    // 标签和游戏功能切换
    public void StageSwitch()
    {
        // 标签和游戏功能
        foreach (GameObject obj in stagesBackup[stageNumCurrent - 1])
        {
            GameObject objPanel = GameManager.instance.GetThisPanel(obj);
            obj.SetActive(false);
            objPanel.SetActive(false);
            Debug.Log(obj.name + " 应当被删除");
            // 加动画
            
        }
        foreach (GameObject obj in stagesBackup[stageNumCurrent])
        {
            GameObject objPanel = GameManager.instance.GetThisPanel(obj);
            obj.SetActive(true);
            objPanel.SetActive(true);
        }
        stageNumCurrent++;

        if (stageNumCurrent == 2)
        {
            CardSender.instance.FlipCards("2");
        }
    }
    
}
