using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinEvent : MonoBehaviour
{
    public List<AudioClip> FinEventAudio;//�ýű��󵽱�ǩ��

    public void Start()//��ʼʱ���Resources�ļ������ָ����Ƶ
    {
        FinEventAudio.Add((AudioClip)Resources.Load("SFX_Event_Complete_1"));
        FinEventAudio.Add((AudioClip)Resources.Load("SFX_Event_Complete_2"));
        FinEventAudio.Add((AudioClip)Resources.Load("SFX_Event_Complete_3"));
    }
    public void FindEvent()//�����ѡ��Ƶ���һ��Ƭ�β���
    {
        GetComponent<AudioSource>().clip = FinEventAudio[Random.Range(0,FinEventAudio.Count)];
        GetComponent<AudioSource>().Play();
    }
}
