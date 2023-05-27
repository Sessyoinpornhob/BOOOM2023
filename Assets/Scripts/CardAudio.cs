using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAudio : MonoBehaviour//�Ѹýű����������һ��ŵ���Ƭ��
{
    public List<AudioClip> ClickAudio;//����ʱ����Ч��
    public List<AudioClip> IntoAudio;//�ѿ�Ƭ�Ž���ǩʱ����Ч��
    public string GetAudioName;//Ҫʹ�õ���Ƶֵ����
    public void Start()//��ʼʱ���Resources�ļ������ָ����Ƶ
    {
        ClickAudio.Add((AudioClip)Resources.Load("SFX_Card_Click_1"));
        ClickAudio.Add((AudioClip)Resources.Load("SFX_Card_Click_2"));
        ClickAudio.Add((AudioClip)Resources.Load("SFX_Card_Click_3"));
        IntoAudio.Add((AudioClip)Resources.Load("SFX_Card_Into_1"));
        IntoAudio.Add((AudioClip)Resources.Load("SFX_Card_Into_2"));
        IntoAudio.Add((AudioClip)Resources.Load("SFX_Card_Into_3"));
    }
    public void OnMouseDown()//�������Ƭʱ����Ч
    {
        GetComponent<AudioSource>().clip = ClickAudio[Random.Range(0, ClickAudio.Count)];
        GetComponent<AudioSource>().Play();
    }
    public void OnMouseUp()//����ɿ�����Ч
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
