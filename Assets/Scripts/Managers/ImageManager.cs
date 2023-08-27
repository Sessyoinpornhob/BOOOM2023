using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{



    public class ImageManager : MonoBehaviour
    {

        // 单例模式
        public static ImageManager instance;
        [Header("CSV查找")] public TextManager textManager;

        void Awake()
        {
            instance = this;
        }

        // 需要读取csv中的字符串，然后在某个位置生成一个Image，将Image组件中的Sprite按照如下路径替换。
        public void SwitchSprite(Image target, string nameInCsv)
        {
            // 空检测，是null直接返回
            if (nameInCsv == "null")
            {
                Debug.Log("no need change");
                return;
            }

            string m_path = "PicSprites/" + nameInCsv;
            Debug.Log("m_path = " + m_path);
            var sp = Resources.Load<Sprite>(m_path);
            Debug.Log(sp);

            target.sprite = sp;


        }

    }
}

