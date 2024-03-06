using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverShooting : MonoBehaviour
{
    #region variables
    [SerializeField] Movment movment;

    [SerializeField] GameObject RevolverTiro;

    [SerializeField] Animator animator;

    [SerializeField] PlayerStateManager playerState;
    [SerializeField] DeadState deadState;

    public int CurrentAmunition;
    int MaxAmuntion = 8;
    public bool cooldownInProgress = false;
    public bool canShoot;
    public int reloadTime;

    #endregion

    private void Awake()
    {
        CurrentAmunition = MaxAmuntion;
        canShoot = true;
    }

    private void Update()
    {
        
        if (playerState.currentState != deadState)
        {
        Reload();
        Shooting();
        }
        else
        {
            Destroy(gameObject);
        }


    }
    public void Shooting()
    {

        if (CurrentAmunition > 0 && canShoot!)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(Cooldown(0.9f));
                animator.SetTrigger("shoot");
                CurrentAmunition--;
                Instantiate(RevolverTiro, transform.position, transform.rotation);
            }
        }

    }
    public void Reload()
    {
        reloadTime = MaxAmuntion - CurrentAmunition;
        if (Input.GetKeyDown(KeyCode.R) && !cooldownInProgress)
        {
            animator.SetTrigger("reload");
            StartCoroutine(ReloadWithDelay(0.3f, reloadTime));
        }
    }

    private IEnumerator ReloadWithDelay(float delay, int reloadCount)
    {
        for (int i = 0; i < reloadCount; i++)
        {
            CurrentAmunition++;
            yield return new WaitForSeconds(delay);
        }
    }

    public IEnumerator Cooldown(float time)
    {
        if (!cooldownInProgress)
        {
            cooldownInProgress = true;

            canShoot = false;
            yield return new WaitForSeconds(time);
            canShoot = true;

            cooldownInProgress = false;
        }
    }

}
