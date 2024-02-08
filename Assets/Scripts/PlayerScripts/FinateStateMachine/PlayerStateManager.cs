using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] public PlayerState currentState;
    SpriteRenderer spriteRenderer;

    [SerializeField] IdleState idleState;
    [SerializeField] WalkingState walkState;
    [SerializeField] CrouchingState crouchingState;
    [SerializeField] DeadState deadState;

    [SerializeField] private Vector2 movementInput;
    private Rigidbody2D playerRigidbody2D;

    Animator playerAnimator;



    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    void Start()
    {
        idleState = GetComponent<IdleState>();
        walkState = GetComponent<WalkingState>();
        crouchingState = GetComponent<CrouchingState>();
        deadState = GetComponent<DeadState>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerAnimator = GetComponent<Animator>();


        TransitionToState(idleState);
    }

    void Update()
    {
       
        currentState.UpdateState();


        if (movementInput != Vector2.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                TransitionToState(crouchingState);
            }
            else
            {
                TransitionToState(walkState);
            }
            
        }
        else
        {
            TransitionToState(idleState);
        }

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
