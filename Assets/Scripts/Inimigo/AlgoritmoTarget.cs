using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AlgoritmoTarget : MonoBehaviour
{
    [SerializeField] Movment movment;
    [SerializeField] VidaZumbi vidaZumbi;

    [SerializeField] AIDestinationSetter destinationSetter;
    [SerializeField] AIPath path;


    #region Variables

    public Transform target;
    public float Speed;

    [SerializeField] private float raioVisao;
    [SerializeField] LayerMask maskPlayer;
    [SerializeField] LayerMask maskAll;

    
    public bool isChasing;
    [SerializeField] float targetTimer = 0f;

    [SerializeField] Transform playerTransform;

    #endregion

    private void Update()
    {

      

      if(vidaZumbi.isDead == true)
      {
          path.maxSpeed = 0f;
      }
      else
      {
          path.maxSpeed = Speed;
      }

      destinationSetter.target = target;

      Chasing();
      SearchPlayer();

    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, raioVisao);

        if (target != null)
        {
            Gizmos.DrawLine(transform.position, target.position);
        }

    }

    private void SearchPlayer()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, raioVisao, maskPlayer);

        if (collider != null)
        {

            Vector2 currentPosition = transform.position;
            Vector2 targetPosition = collider.transform.position;
            Vector2 direction = targetPosition - currentPosition;

            direction = direction.normalized;
            RaycastHit2D hit = Physics2D.Raycast(currentPosition, direction, raioVisao, maskAll);

            if (hit.transform != null && hit.transform.CompareTag("Player"))
            {
                if(movment.IsDead != true)
                {
                    target = hit.transform;
                }
                else
                {
                    target = null;
                }
                
            }
            else
            {
                target = null;
            }
        }
        else
        {
            target = null;
        }
    }

    private void RaioVisao()
    {
        if (movment.Sound > 100f)
        {
            raioVisao = 8f;
        }
        else if (movment.Sound > 50f && movment.Sound <= 100f)
        {
            raioVisao = 5f;
        }
        else
        {
            raioVisao = 2f;
        }
    }

    private void Chasing()
    {


        if (target != null && target.CompareTag("Player"))
        {
            targetTimer += Time.deltaTime;
            if (targetTimer > 3f)
            {
                isChasing = true;
            }
        }
        else
        {
            targetTimer = 0f;
        }
        if (isChasing)
        {
            raioVisao = 10f;
        }
        else if (vidaZumbi.CurrentVida != vidaZumbi.MaxVida)
        {
            isChasing = true;
        }
        else
        {
            RaioVisao();
        }

        


    }



}
