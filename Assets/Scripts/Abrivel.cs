using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class NewBehaviourScript : Interactable
{
    public Sprite Open;
    public Sprite Close;

    private SpriteRenderer sr;
    private bool isOpen;

    public override void Interact()
    {
        if(isOpen!)
        {
            sr.sprite = Close;
            
        }
        else
        {
            sr.sprite = Open;
            
        }
        isOpen = !isOpen;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Close;
    }


}
