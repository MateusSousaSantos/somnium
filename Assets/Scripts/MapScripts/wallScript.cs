using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class wallScript : MonoBehaviour
{
    Tilemap tilemap;
    Collider2D col;

    [SerializeField] public Color opacity;
    

    
    private float targetOpacity;
    



    void Start()
    {
        col = GetComponent<Collider2D>();
        tilemap = GetComponent<Tilemap>();
        col.isTrigger = true;
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            targetOpacity = 0f;


            opacity.a = targetOpacity;
            tilemap.color = opacity; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            targetOpacity = 1f;


            opacity.a = targetOpacity;
            tilemap.color = opacity;
        }
    }


}
