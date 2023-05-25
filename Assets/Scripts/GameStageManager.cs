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
    public List<List<GameObject>> stagesBackup = new List<List<GameObject>>();
    public List<GameObject> stage01Backup = new List<GameObject>();
    public List<GameObject> stage02Backup = new List<GameObject>();
    public List<GameObject> stage03Backup = new List<GameObject>();

    
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
        stage01Backup = stage01;
        stage02Backup = stage02;
        stage03Backup = stage03;
        stagesBackup.Add(stage01Backup);
        stagesBackup.Add(stage02Backup);
        stagesBackup.Add(stage03Backup);
        
        Debug.Log(stagesBackup[0][0].name);

        //stagesBackup = DeepCopy(stages);
    }

    
    // 深度拷贝List stages
    public List<List<GameObject>> DeepCopy(List<List<GameObject>> original)
    {
        List<List<GameObject>> copy = new List<List<GameObject>>();
        foreach (List<GameObject> list in original)
        {
            List<GameObject> newList = new List<GameObject>();
            foreach (GameObject obj in list)
            {
                GameObject newObj = Instantiate(obj);
                newList.Add(newObj);
            }
            copy.Add(newList);
        }
        return copy;
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
            StageSwitch();
        }
    }

    // DisActive本阶段所有的Label，Active下个阶段所有的Label
    public void StageSwitch()
    {
        foreach (GameObject obj in stagesBackup[stageNumCurrent - 1])
        {
            obj.SetActive(false);
            Debug.Log(obj.name + " 应当被删除");
        }
        foreach (GameObject obj in stagesBackup[stageNumCurrent])
        {
            obj.SetActive(true);
        }
        stageNumCurrent++;
    }
    
    
    
}
