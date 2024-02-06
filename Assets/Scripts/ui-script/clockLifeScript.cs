using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clockLifeScript : MonoBehaviour
{
    Image relogioLife;
    [SerializeField] PlayerEstatisticas estatisticas;

    [SerializeField] Sprite[] sprites = new Sprite[7];
    void Start()
    {
        relogioLife = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //100
        if(estatisticas.CurrentVida >= 87)
        {
            relogioLife.sprite = sprites[0];
        }
        //87
        if (estatisticas.CurrentVida >= 74 && estatisticas.CurrentVida <= 87)
        {
            relogioLife.sprite = sprites[1];
        }
        //74
        if (estatisticas.CurrentVida <= 74 && estatisticas.CurrentVida >= 61)
        {
            relogioLife.sprite = sprites[2];
        }
        //61
        if (estatisticas.CurrentVida <= 61 && estatisticas.CurrentVida >= 47)
        {
            relogioLife.sprite = sprites[3];
        }
        //48
        if (estatisticas.CurrentVida <= 47 && estatisticas.CurrentVida >= 34)
        {
            relogioLife.sprite = sprites[4];
        }
        //35
        if (estatisticas.CurrentVida <= 34 && estatisticas.CurrentVida >= 20)
        {
            relogioLife.sprite = sprites[5];
        }
        //10
        if (estatisticas.CurrentVida <= 20 && estatisticas.CurrentVida >= 1)
        {
            relogioLife.sprite = sprites[6];
        }


    }
}
