using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movment : MonoBehaviour
{


    public float Speed;
    public float Sound;

    float MinSpeed = 2f;
    public float MaxSpeed = 5f;

    [SerializeField] SpriteRenderer spriteRenderer;
    private Rigidbody2D Rigidbody2D;
    private Vector2 movementInput;
    private Vector2 smoothMovementInput;
    private Vector2 smoothMovementImputVelocity;
    public bool Player_ControlCharacter;

    public bool IsWalking = false;
    public bool IsCrouching = false;
    public bool IsDead = false;
    public bool IsAiming = false;

    [SerializeField] RevolverShooting revolverShooting;
    [SerializeField] Animator animator;
    [SerializeField] Animator buttonAnimator;

    private Vector2 boxSize = new Vector2(1f, 1f);

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Player_ControlCharacter = true;

    }

    private void OnMove(InputValue inputValue)
    {
        
        movementInput = inputValue.Get<Vector2>();
        animator.SetBool("isDead", false);
       

    }

    private void Update()
    {
       

        if (!IsDead)//retirar isso casso erro
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChekInteraction();
            }

            if (revolverShooting.canShoot!)
            {
                Sound = (Speed * 100) / MaxSpeed;
            }
            else if (revolverShooting.canShoot == false)
            {
                Sound = (Speed * 100) / MaxSpeed + 70;
            }


            if (Player_ControlCharacter == true) 
            {

                smoothMovementInput = Vector2.SmoothDamp(
                    smoothMovementInput,
                    movementInput,
                    ref smoothMovementImputVelocity,
                    0.1f
                    );
                Rigidbody2D.velocity = smoothMovementInput * Speed;

                if (IsWalking! && !IsCrouching){
                    Speed = MaxSpeed;
                }
                else if (Player_ControlCharacter == false)
                {
                    Speed = 0;
                }
                else if (IsDead!)
                {
                    Speed = 0;
                }
                else
                {
                    Speed = MinSpeed;
                }

                if (Rigidbody2D.velocity != Vector2.zero)
                {
                    IsWalking = true;
                }
                else
                {
                    IsWalking = false;
                }

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    animator.SetBool("isCrouching", true);
                    IsCrouching = true;
                }
                else
                {
                    animator.SetBool("isCrouching", false);
                    IsCrouching = false;
                }

                if (IsWalking!)
                {
                    animator.SetBool("isMoving", true);
                }
                else
                {
                    animator.SetBool("isMoving", false);
                }

                if (Rigidbody2D.velocity.x > 0)
                {

                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }

                if (Input.GetButton("Fire2"))
                {
                    IsAiming = true;
                }
                else
                {
                    IsAiming = false;
                }
            }

        }
    }

    public void ChekInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if(hits.Length > 0 )
        {
            foreach(RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    buttonAnimator.SetTrigger("press");
                }
            }
        }
    }
   
}
