using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class bullet : MonoBehaviour
{
    public LayerMask ignoredLayer;
    public GameObject HitEffect;
    public GameObject HitEffect2;
    public GameObject smokeEffect;
   // public zumbi_vida zumbi_Vida;

    private void OnTriggerEnter2D(Collider2D collision)
    {

      
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {


            
            GameObject effect = Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(effect, 2f);

            Debug.Log("<color=red>dano20</color>");
            Destroy(gameObject);
            
        }
        else
        {
            
            GameObject effect2 = Instantiate(HitEffect2, transform.position, transform.rotation);
            Destroy(effect2, 2f);
            GameObject smoke = Instantiate(smokeEffect, transform.position, transform.rotation);
            Destroy(smoke, 2f);
            Destroy(gameObject);
        }

    }

    
}


