using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zumbi_vida : MonoBehaviour
{
    public int currentLife;
    public int maxLife = 130;




    void Start()
    {
        currentLife = maxLife;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("<color=red>DANO</color>");
        currentLife -= damage;
        if(currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
