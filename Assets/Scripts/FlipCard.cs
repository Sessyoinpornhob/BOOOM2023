using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    public float x, y, z;
    public GameObject cardBack;
    public GameObject cardFront;
    public bool cardBackIsActive;
    public int timer;
    public int canFlipCpunt;

    [Header("翻卡时间")]
    [Range(0, 1)]
    public float flipTime;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //canFlipCpunt = 1;
    }
    

    // 最后由程序告诉编辑器，何时翻面（按照阶段）
    public void StartFlip()
    {
        if (canFlipCpunt > 0)
        {
            StartCoroutine(CalculateFlip());
        }

        gameObject.GetComponent<Card>().canUse = true;

    }

    public void Flip()
    {
        if (cardBackIsActive == true)
        {
            cardBack.SetActive(false);
            cardBackIsActive = false;
            cardFront.SetActive(true);
        }
        else
        {
            cardBack.SetActive(true);
            cardBackIsActive = true;
            cardFront.SetActive(false);
        }
    }

    IEnumerator CalculateFlip()
    {
        for (int i = 0; i < 180; i++)
        {
            yield return new WaitForSeconds(0.01f * flipTime);
            transform.Rotate(new Vector3(x,y,z));
            timer++;

            if (timer == 90 || timer == -90)
            {
                Flip();
            }
        }

        timer = 0;
        canFlipCpunt--;
    }
    
}
