using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class AbrirPorta : Interactable
{

    public Sprite Open;
    public Sprite Close;
    [SerializeField] BoxCollider2D boxCollider2D;

    private SpriteRenderer sr;
    private bool isOpen;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Close;
        boxCollider2D.isTrigger = false;

    }

    public override void Interact()
    {
        if (isOpen!)
        {
            sr.sprite = Close;
            boxCollider2D.isTrigger = false;
        }
        else
        {
            sr.sprite = Open;
            boxCollider2D.isTrigger = true;

        }
        isOpen = !isOpen;
    }
}
