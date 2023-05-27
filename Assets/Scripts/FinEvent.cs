using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinEvent : MonoBehaviour
{
    public List<AudioClip> FinEventAudio;//该脚本绑到便签上

    public void Start()//开始时获得Resources文件夹里的指定音频
    {
        FinEventAudio.Add((AudioClip)Resources.Load("SFX_Event_Complete_1"));
        FinEventAudio.Add((AudioClip)Resources.Load("SFX_Event_Complete_2"));
        FinEventAudio.Add((AudioClip)Resources.Load("SFX_Event_Complete_3"));
    }
    public void FindEvent()//随机挑选音频里的一个片段播放
    {
        GetComponent<AudioSource>().clip = FinEventAudio[Random.Range(0,FinEventAudio.Count)];
        GetComponent<AudioSource>().Play();
    }
}
