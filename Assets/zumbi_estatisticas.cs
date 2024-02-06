using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zumbi_estatisticas : MonoBehaviour
{

    public int currentLifeZumbi;
    public int maxLifeZumbi = 130;
    private void Start()
    {

        currentLifeZumbi = maxLifeZumbi;
        
    }

    public void TakeDamage(int damage)
    {
        currentLifeZumbi -= damage;
        if (currentLifeZumbi < 0)
        {
            Debug.Log("<color=red>Morreu</color>");
        }
}
    }
