using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    public float speed = 0f;

    public int life = 10;

    public float Sound = 15f;

   
    public void OnTakingDamaged(int Damage)
    {
        life -= Damage;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Sound = (100 * speed) / 5;
    }
}
