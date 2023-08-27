using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        [Header("三个音效组")] public List<AudioClip> clickAudio; //触摸时的音效组
        public List<AudioClip> intoAudio; //把卡片放进便签时的音效组
        public List<AudioClip> finEventAudio; //该脚本绑到便签上

        void Awake()
        {
            instance = this;
        }

        public void Start() //开始时获得Resources文件夹里的指定音频
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

        // 随机播放
        public float GetClickAudio()
        {
            GetComponent<AudioSource>().Pause();
            GetComponent<AudioSource>().clip = null;
            GetComponent<AudioSource>().clip = clickAudio[Random.Range(0, clickAudio.Count)];
            GetComponent<AudioSource>().Play();

            return GetComponent<AudioSource>().clip.length;
        }

        // 一样的
        public float GetIntoAudio()
        {
            GetComponent<AudioSource>().Pause();
            GetComponent<AudioSource>().clip = null;
            GetComponent<AudioSource>().clip = intoAudio[Random.Range(0, intoAudio.Count)];
            GetComponent<AudioSource>().Play();

            return GetComponent<AudioSource>().clip.length;
        }

        // 随机播放
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
