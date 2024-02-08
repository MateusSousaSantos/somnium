using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeadState : PlayerState
{


    PlayerStats playerStats;
    Animator Playeranimator;
    [SerializeField] GameObject bodyPrefab;

    private Vector3 originalPosition;
    bool cooldownInProgress = false;


    public override void EnterState(PlayerStateManager playerMovement)
    {
        playerStats = GetComponent<PlayerStats>();
        Dead();
    }

    public override void UpdateState()
    {
    }

    private IEnumerator SpawnBodyAfterAnimation()
    {
        yield return new WaitForSeconds(1f);

        Instantiate(bodyPrefab, originalPosition, Quaternion.identity);

        Destroy(gameObject);
    }
    public void Dead()
    {
        if (!cooldownInProgress)
        {
            cooldownInProgress = true;
            Playeranimator.SetBool("isDead", true);
            originalPosition = transform.position;
            SpawnBodyAfterAnimation();
        }
    }

}
