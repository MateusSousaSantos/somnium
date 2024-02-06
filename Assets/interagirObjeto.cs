using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interagirObjeto : MonoBehaviour
{

    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

}
