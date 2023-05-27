using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAudio : MonoBehaviour//把该脚本和音量组件一起放到卡片里
{
    public List<AudioClip> ClickAudio;//触摸时的音效组
    public List<AudioClip> IntoAudio;//把卡片放进便签时的音效组
    public string GetAudioName;//要使用的音频值名字
    public void Start()//开始时获得Resources文件夹里的指定音频
    {
        ClickAudio.Add((AudioClip)Resources.Load("SFX_Card_Click_1"));
        ClickAudio.Add((AudioClip)Resources.Load("SFX_Card_Click_2"));
        ClickAudio.Add((AudioClip)Resources.Load("SFX_Card_Click_3"));
        IntoAudio.Add((AudioClip)Resources.Load("SFX_Card_Into_1"));
        IntoAudio.Add((AudioClip)Resources.Load("SFX_Card_Into_2"));
        IntoAudio.Add((AudioClip)Resources.Load("SFX_Card_Into_3"));
    }
    public void OnMouseDown()//鼠标点击卡片时的音效
    {
        GetComponent<AudioSource>().clip = ClickAudio[Random.Range(0, ClickAudio.Count)];
        GetComponent<AudioSource>().Play();
    }
    public void OnMouseUp()//鼠标松开的音效
    {
        GetComponent<AudioSource>().clip = ClickAudio[Random.Range(0, IntoAudio.Count)];
        GetComponent<AudioSource>().Play();
    }

    public void Update()
    {
        if (GetAudioName != null)
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat(GetAudioName);
        }
    }
}
