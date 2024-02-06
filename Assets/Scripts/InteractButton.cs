using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class InteractButton : MonoBehaviour
{
    [SerializeField] Renderer buttom;
    Vector2 posiçãoAtual;
    Vector2 posiçãoAlvo;
    Vector2 direção;



    private void Start()
    {
        buttom.enabled = false;
    }

    private void Reset()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
             buttom.enabled = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buttom.enabled=false;
        }
    }
}
