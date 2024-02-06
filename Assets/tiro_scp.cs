using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro_scp : MonoBehaviour
{
    
    public GameObject HitEffect;
    public GameObject HitEffect2;

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
            zumbi_vida zumbi_Vida = collision.gameObject.GetComponent<zumbi_vida>();
            zumbi_Vida.TakeDamage(20);
            Destroy(gameObject);

        }
        else
        {

            GameObject effect2 = Instantiate(HitEffect2, transform.position, transform.rotation);
            Destroy(effect2, 2f);
            Destroy(gameObject);
        }

    }
}
