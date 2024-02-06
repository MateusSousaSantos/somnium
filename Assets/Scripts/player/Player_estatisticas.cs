using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_estatisticas : MonoBehaviour
{

    private float max_life = 100f;
    public  float current_life;
    private float max_sanity = 100f;
    public  float current_sanity;


    void Start()
    {
        current_life = max_life;
        current_sanity = max_sanity;
    }

}
