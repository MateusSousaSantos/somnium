using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerStateManager;

public class CrouchingState : PlayerState
{
    private Rigidbody2D playerRigidbody2D;

    private Vector2 movementInput;
    private Vector2 smoothMovementInput;
    private Vector2 smoothMovementImputVelocity;

    PlayerStats playerStats;
    Animator playerAnimator;
    PlayerStateManager stateManager;

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    public override void EnterState(PlayerStateManager playerMovement)
    {
        base.EnterState(playerMovement);
        playerStats = GetComponent<PlayerStats>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        stateManager = GetComponent<PlayerStateManager>();

        playerAnimator.SetBool("isCrouching", true);
        playerAnimator.SetBool("isWalking", true);
    }

    public override void UpdateState()
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (movementInput == Vector2.zero) stateManager.TransitionToState(stateManager.idleState);
        }
        else
        {
            stateManager.TransitionToState(stateManager.walkState);
        }

        smoothMovementInput = Vector2.SmoothDamp(
            smoothMovementInput,
            movementInput,
            ref smoothMovementImputVelocity,
            0.1f
        );
        playerRigidbody2D.velocity = movementInput * (playerStats.speed/2);
    }

    public override void ExitState()
    {
        base.ExitState();
        playerAnimator.SetBool("isCrouching", false);
        playerAnimator.SetBool("isWalking", false);
    }


}


