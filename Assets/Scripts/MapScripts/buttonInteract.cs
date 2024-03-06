using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonInteract : MonoBehaviour
{

    SpriteRenderer sr;
    [SerializeField] Sprite toPress;
    [SerializeField] Sprite Pressed;
    [SerializeField] Sprite none;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = none;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pressed");
                sr.sprite = Pressed;
            }
            else
            {
                sr.sprite = toPress;
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        sr.sprite = none;
    }

}
