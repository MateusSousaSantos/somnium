using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverTiro : MonoBehaviour
{

    public GameObject Sangue;
    public GameObject Smoke;
    public float bulletVelocity;

    private Vector2 boxSize = new Vector2(0.5f, 05f);

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * bulletVelocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject effect = Instantiate(Sangue, transform.position, transform.rotation);
            Destroy(effect, 0.7f);

            RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

            if (hits.Length > 0)
            {
                foreach (RaycastHit2D rc in hits)
                {
                    if (rc.transform.GetComponent<TakeDamage>())
                    {
                        rc.transform.GetComponent<TakeDamage>().ReceiveDamage(20);
                    }
                }
            }

            Destroy(gameObject);

        }
        else
        {

            RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

            if (hits.Length > 0)
            {
                foreach (RaycastHit2D rc in hits)
                {
                    if (rc.transform.GetComponent<TakeDamage>())
                    {
                        rc.transform.GetComponent<TakeDamage>().ReceiveDamage(20);
                    }
                }
            }

            GameObject effect = Instantiate(Smoke, transform.position, transform.rotation);
            Destroy(effect, 2f);
            Destroy(gameObject);
        }

    }
}
