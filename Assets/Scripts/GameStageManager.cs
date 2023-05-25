using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 设计这个class是为了在Label和Game之间再增加一个层，便于各种情况下的控制。
public class GameStageManager : MonoBehaviour
{
    public int stageNumCurrent = 1;
    
    public List<GameObject> stage01 = new List<GameObject>();
    public List<GameObject> stage02 = new List<GameObject>();
    public List<GameObject> stage03 = new List<GameObject>();
    public List<List<GameObject>> stages = new List<List<GameObject>>();

    void Start()
    {
        stages.Add(stage01);
        stages.Add(stage02);
        stages.Add(stage03);
        Debug.Log("we have " + stages.Count + " stages");
        // 通过泛型列表查到当前stage的对应列表（和里面的GameObjects）
        Debug.Log("we are in the stage " + stages[stageNumCurrent - 1]);
    }

    // 将已完成的某个Icon传递到此函数中，在对应的列表里删除东西
    public void StageUpdate(GameObject finishedIcon)
    {
        Debug.Log("finishedIcon is ----> " + finishedIcon.name);
        
    }
    
    // 检测本Stage是否完成
    // 整个判定的逻辑和卡牌在Panel中的判定基本上一样，为什么还要写一遍...
    public void StageCheck()
    {
        
    }
}
