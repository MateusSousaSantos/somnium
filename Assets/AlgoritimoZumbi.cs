using UnityEngine;
using Pathfinding;

public class AlgoritimoZumbi : MonoBehaviour
{
    #region Variables

    [SerializeField] Movment movment;
    //[SerializeField] AIDestinationSetter destinationSetter;
    public Transform target;

    [SerializeField] private float raioVisao;
    [SerializeField] LayerMask maskPlayer;

    public bool isChasing;
    //[SerializeField] float targetTimer = 0f;

    [SerializeField] Transform playerTransform;

    #endregion

    private void Update()
    {
        SearchPlayer(); 
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, raioVisao);

        if(target  != null)
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
            RaycastHit2D hit = Physics2D.Raycast(currentPosition, direction,raioVisao);


            if (hit.transform != null)
            {
                if (collider.transform.CompareTag("Player"))
                {
                    target = hit.transform;
                    Debug.Log("Player");
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
}
