using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_movement : MonoBehaviour
{
      
    

    public float Speed;
    public float MinSpeed = 0f;
    public float MaxSpeed = 20f;
    public float WalkingSpeed = 1f;
    public float Pitch;

    private Rigidbody2D Rigidbody2D;
    private Vector2 _movementInput;
    private Vector2 smoothMovementInput;
    private Vector2 smoothMovementImputVelocity;
    public bool Current_Control;

    private void Awake()
    {
        MaxSpeed = 20f;
        Speed = MaxSpeed;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Current_Control = true;

       

    } 
    private void OnMove(InputValue inputValue)
    {
       _movementInput = inputValue.Get<Vector2>();
    }
    public void SoundClue()
    {
        Pitch = (Speed * 100) / MaxSpeed;

    }
    private void FixedUpdate()
    {

        
        if (Current_Control == true) {

        smoothMovementInput = Vector2.SmoothDamp(
            smoothMovementInput,
            _movementInput,
            ref smoothMovementImputVelocity,
            0.1f
            );
        Rigidbody2D.velocity = smoothMovementInput * Speed;

        }
        else
        {
            return;
        }


    }

 
}
