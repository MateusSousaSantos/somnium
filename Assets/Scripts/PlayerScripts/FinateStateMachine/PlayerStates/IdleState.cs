using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerStateManager;

public class IdleState : PlayerState
{
    PlayerStats playerStats;
    Animator playerAnimator;
    PlayerStateManager stateManager;
    [SerializeField] private Vector2 movementInput;

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    public override void EnterState(PlayerStateManager playerMovement)
    {
        base.EnterState(playerMovement);
        playerStats = GetComponent<PlayerStats>();
        playerAnimator = GetComponent<Animator>();
        stateManager = GetComponent<PlayerStateManager>();
        
    }

    public override void UpdateState()
    {
        if (movementInput != Vector2.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift)) { 
            stateManager.TransitionToState(stateManager.crouchingState);
            
            } 
            else{
            stateManager.TransitionToState(stateManager.walkState);

            }

        }
        

    }

    public override void FixedUpdateState()
    {
        
    }
}