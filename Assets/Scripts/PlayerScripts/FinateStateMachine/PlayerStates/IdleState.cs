using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerStateManager;

public class IdleState : PlayerState
{
    PlayerStats playerStats;
    Animator playerAnimator;

    public override void EnterState(PlayerStateManager playerMovement)
    {
        base.EnterState(playerMovement);
        playerStats = GetComponent<PlayerStats>();
        playerAnimator = GetComponent<Animator>();

        playerStats.speed = 0;
    }

    public override void UpdateState()
    {
       
    }

    public override void FixedUpdateState()
    {
        
    }
}