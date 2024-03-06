using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_shooting : MonoBehaviour
{
    public LayerMask ignoredLayer;
    public GameObject HitEffect;
    public GameObject HitEffect2;
    public GameObject smokeEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {


            zumbi_vida zumbi_Vida = collision.gameObject.GetComponent<zumbi_vida>();
            GameObject effect = Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(effect, 2f);
            zumbi_Vida.TakeDamage(20);
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
