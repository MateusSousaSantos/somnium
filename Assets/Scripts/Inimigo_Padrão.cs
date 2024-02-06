using CodeMonkey.Utils;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

public class Inimigo_Padrão : MonoBehaviour
{
    #region Variables 

    [SerializeField] AIDestinationSetter destinationSetter;
    public Transform target;
    public LayerMask mask;
    public LayerMask mask2;
    
    

    [SerializeField] Rigidbody2D rigidBody2D;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite spriteFrente;
    [SerializeField] Sprite spriteCostas;
    [SerializeField] float minDistance;

    //[SerializeField] bool Chasing = false;
    #endregion Variables

    Collider2D colider;
    Collider2D colider2;
    Vector2 posiçãoAtual;
    Vector2 posiçãoAlvo;
    Vector2 direção;

    public float raioVisao;
    public float raioVisao2;

    bool cooldownInProgress;
    public bool canAtack;

    public float target_distance;

    private void Start()
    {
        canAtack = true;
       
        raioVisao = 22f;
        raioVisao2 = 3f;
        spriteRenderer.sprite = spriteFrente;
    }
    private void Update()
    {

       

        SearchPlayer();


    }


    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere( this.transform.position,raioVisao);
        
        if (this.target != null )
        {
            Gizmos.DrawLine(this.transform.position,this.target.position);
        }

    }
    /* public void SearchPlayer()
     {
         colider = Physics2D.OverlapCircle(this.transform.position, raioVisao,mask);



         if (colider != null)
         {

             posiçãoAtual = this.transform.position;
             posiçãoAlvo = colider.transform.position;
             direção = posiçãoAlvo - posiçãoAtual;
             direção = direção.normalized;


             RaycastHit2D hit = Physics2D.Raycast(posiçãoAtual, direção,raioVisao,mask2);
             if(hit.transform != null)
             {
                 if (hit.transform.CompareTag("Player"))
                 {
                     target = hit.transform;
                 }
                 else
                 {
                     this.target = null;
                 }
             }
             else
             {
                 this.target = null;
             }
         }
         else
         {
             this.target = null;
         }
     }*/
    public void SearchPlayer()
    {
        colider = Physics2D.OverlapCircle(this.transform.position, raioVisao, mask);

        if (colider != null)
        {
            posiçãoAtual = this.transform.position;
            posiçãoAlvo = colider.transform.position;
            direção = posiçãoAlvo - posiçãoAtual;
            direção = direção.normalized;

            RaycastHit2D hit = Physics2D.Raycast(posiçãoAtual, direção, raioVisao, mask2);
            if (hit.transform != null)
            {
                if (colider2 != null)
                {
                    target = hit.transform;
                }
                if (hit.transform.CompareTag("Player"))
                {
                    target = hit.transform;
                }
                else
                {
                    this.target = null;
                }
            }
            else
            {
                this.target = null;
            }
        }
        else
        {
            this.target = null;
        }
    }

    public void PararInimigo()
    {
        this.rigidBody2D.velocity = Vector2.zero;
    }
    public void MoverInimigo()
    {


            if (this.rigidBody2D.velocity.x > 0)
            {
                this.spriteRenderer.flipX = false;
            }
            else
            {
                this.spriteRenderer.flipX = true;
            }
            if (this.rigidBody2D.velocity.y > 0)
            {
                spriteRenderer.sprite = spriteCostas;
            }
            else
            {
                spriteRenderer.sprite = spriteFrente;
            }
    }
    public IEnumerator Cooldown(float time)
    {
        if (!cooldownInProgress)
        {
            cooldownInProgress = true;

            canAtack = false;
            

            yield return new WaitForSeconds(time);

            
            canAtack = true;

            cooldownInProgress = false;
        }
    }

    public IEnumerator SlowDown(float time)
    {
        canAtack = false;
        yield return new WaitForSeconds(time);
        canAtack = true;
    }
}
