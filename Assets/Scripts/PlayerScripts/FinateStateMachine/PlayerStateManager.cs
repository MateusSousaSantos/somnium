using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] public PlayerState currentState;
    PlayerStats playerStats;
    SpriteRenderer spriteRenderer;

    public IdleState idleState;
    public WalkingState walkState;
    public CrouchingState crouchingState;
    [SerializeField] DeadState deadState;

    
    private Rigidbody2D playerRigidbody2D;

    Animator playerAnimator;




    void Start()
    {
        idleState = GetComponent<IdleState>();
        walkState = GetComponent<WalkingState>();
        crouchingState = GetComponent<CrouchingState>();
        deadState = GetComponent<DeadState>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerStats = GetComponent<PlayerStats>();
        playerAnimator = GetComponent<Animator>();


        TransitionToState(idleState);
    }

    void FixedUpdate()
    {
        currentState.UpdateState();

    }


    public void TransitionToState(PlayerState state)
    {
        currentState?.ExitState();
        currentState = state;
        currentState.EnterState(this);
    }
}

    
public abstract class PlayerState : MonoBehaviour
{
    protected PlayerStateManager playerStateManager;

    public virtual void EnterState(PlayerStateManager playerMovement)
    {
        this.playerStateManager = playerMovement;
    }

    public abstract void UpdateState();

    public virtual void FixedUpdateState() { }

    public virtual void ExitState() { }
}
