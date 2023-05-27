using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    //这是一个设置音量大小的脚本
    public void Start()//根据音量设置来调着子物体的进度条长度
    {
        GetComponentsInChildren<Slider>()[0].value = PlayerPrefs.GetFloat("BGM");//Bgm的音量条
        GetComponentsInChildren<Slider>()[1].value = PlayerPrefs.GetFloat("AMB");//环境音的音量条
        GetComponentsInChildren<Slider>()[2].value = PlayerPrefs.GetFloat("EFF");//音效的音量条
    }
    public void BGMSetting(Slider BGMSlider)//通过进度条上的按钮触发  BGMSlider即为按钮进度条本身
    {
        PlayerPrefs.SetFloat("BGM",BGMSlider.value);//获得进度条上的value值 把该值赋值到音乐播放组件的强度上
    }

    public void AMBSetting(Slider AMBSlider)
    {
        PlayerPrefs.SetFloat("AMB", AMBSlider.value);
    }
    public void EFFSetting(Slider EFFSlider)
    {
        PlayerPrefs.SetFloat("EFF", EFFSlider.value);
    }
}
