using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        [Header("������Ч��")] public List<AudioClip> clickAudio; //����ʱ����Ч��
        public List<AudioClip> intoAudio; //�ѿ�Ƭ�Ž���ǩʱ����Ч��
        public List<AudioClip> finEventAudio; //�ýű��󵽱�ǩ��

        void Awake()
        {
            instance = this;
        }

        public void Start() //��ʼʱ���Resources�ļ������ָ����Ƶ
        {
            clickAudio.Add((AudioClip) Resources.Load("Sounds/SFX_Card_Click_1"));
            clickAudio.Add((AudioClip) Resources.Load("Sounds/SFX_Card_Click_2"));
            clickAudio.Add((AudioClip) Resources.Load("Sounds/SFX_Card_Click_3"));

            intoAudio.Add((AudioClip) Resources.Load("Sounds/SFX_Card_Into_1"));
            intoAudio.Add((AudioClip) Resources.Load("Sounds/SFX_Card_Into_2"));
            intoAudio.Add((AudioClip) Resources.Load("Sounds/SFX_Card_Into_3"));

            finEventAudio.Add((AudioClip) Resources.Load("Sounds/SFX_Event_Complete_1"));
            finEventAudio.Add((AudioClip) Resources.Load("Sounds/SFX_Event_Complete_2"));
            finEventAudio.Add((AudioClip) Resources.Load("Sounds/SFX_Event_Complete_3"));
        }

        // �������
        public float GetClickAudio()
        {
            GetComponent<AudioSource>().Pause();
            GetComponent<AudioSource>().clip = null;
            GetComponent<AudioSource>().clip = clickAudio[Random.Range(0, clickAudio.Count)];
            GetComponent<AudioSource>().Play();

            return GetComponent<AudioSource>().clip.length;
        }

        // һ����
        public float GetIntoAudio()
        {
            GetComponent<AudioSource>().Pause();
            GetComponent<AudioSource>().clip = null;
            GetComponent<AudioSource>().clip = intoAudio[Random.Range(0, intoAudio.Count)];
            GetComponent<AudioSource>().Play();

            return GetComponent<AudioSource>().clip.length;
        }

        // �������
        public float GetFinishEventAudio()
        {
            GetComponent<AudioSource>().Pause();
            GetComponent<AudioSource>().clip = null;
            GetComponent<AudioSource>().clip = finEventAudio[Random.Range(0, finEventAudio.Count)];
            GetComponent<AudioSource>().Play();

            return GetComponent<AudioSource>().clip.length;
        }
    }
}
