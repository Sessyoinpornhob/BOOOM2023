using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAudioSetting : MonoBehaviour//����������ȡ�������õĽű� ���԰��κη����������� ������Ҫ������Ƶ����(���������� ���� ��Ч)
{
    public string GetAudioName;//Ҫʹ�õ���Ƶֵ����
    //BGM��Ƶ��ΪBGM
    //������ΪAMB
    //��ЧΪEFF

    public void Update()
    {
        if (GetAudioName!=null)//�����Ƶ���ֲ��ǿ�
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat(GetAudioName);//���������������ǿ�ȵ���������������Ƶ���ֵ�ǿ��
        }
    }
}
