using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    //����һ������������С�Ľű�
    public void Start()//������������������������Ľ���������
    {
        GetComponentsInChildren<Slider>()[0].value = PlayerPrefs.GetFloat("BGM");//Bgm��������
        GetComponentsInChildren<Slider>()[1].value = PlayerPrefs.GetFloat("AMB");//��������������
        GetComponentsInChildren<Slider>()[2].value = PlayerPrefs.GetFloat("EFF");//��Ч��������
    }
    public void BGMSetting(Slider BGMSlider)//ͨ���������ϵİ�ť����  BGMSlider��Ϊ��ť����������
    {
        PlayerPrefs.SetFloat("BGM",BGMSlider.value);//��ý������ϵ�valueֵ �Ѹ�ֵ��ֵ�����ֲ��������ǿ����
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
