using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAudioSetting : MonoBehaviour//这是用来获取音量设置的脚本 可以绑到任何发声的物体上 但是需要设置音频名字(即背景音乐 或者 音效)
{
    public string GetAudioName;//要使用的音频值名字
    //BGM音频名为BGM
    //环境音为AMB
    //音效为EFF

    public void Update()
    {
        if (GetAudioName!=null)//如果音频名字不是空
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat(GetAudioName);//该音量组件的声音强度等于音量设置里音频名字的强度
        }
    }
}
