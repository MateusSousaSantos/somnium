using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZumbi : MonoBehaviour
{

    [SerializeField] AlgoritmoTarget algoritmo;
    [SerializeField] Movment mv;
    [SerializeField] float Distance;
    private Vector2 boxSize = new Vector2(1.2f, 1.2f);
    

    Animator animator;
    public bool cooldownInProgress = false;
    public bool canAttack = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        canAttack = true;
    }
    private void Update()
    {

        if(algoritmo.target != null)
        {
            Distance = Vector2.Distance(transform.position, algoritmo.target.position);
        }
        Attack();
    }

    private void Attack()
    {
        if(canAttack!)
        {

        if(algoritmo.target != null && Vector2.Distance(transform.position, algoritmo.target.position) < 1.2f) 
        {

            RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position,boxSize, 0, Vector2.zero);

            if (hits.Length > 0)
            {
                foreach (RaycastHit2D rc in hits)
                {
                    if (rc.transform.GetComponent<TomarDano>())
                    {
                        rc.transform.GetComponent<TomarDano>().Ataque(25);
                            animator.SetTrigger("attack");
                            StartCoroutine(Cooldown(2f));
                    }
                }
            }

        }

        }

    }

    public IEnumerator Cooldown(float time)
    {
        if (!cooldownInProgress)
        {
            cooldownInProgress = true;

            mv.MaxSpeed -= 2.5f;
            canAttack = false;
            yield return new WaitForSeconds(time);
            canAttack = true;
            mv.MaxSpeed += 2.5f;

            cooldownInProgress = false;
        }
    }


}
