
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class player_sprites : MonoBehaviour
{
    [SerializeField]player_movement player_movement;
    [SerializeField] PlayerAim player_aim;
    [SerializeField]SpriteRenderer spriteRenderer;
    [SerializeField]
    Sprite frente;
    [SerializeField]
    Sprite sprite2;
    [SerializeField]
    Sprite sprite3;
    [SerializeField]
    Sprite sprite4;
    [SerializeField]
    Sprite sprite5;
    [SerializeField] Animator animator;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player_aim = GetComponent<PlayerAim>();
              //  transform.localRotation = Quaternion.Euler(0, 180, 0);

    }

    void FixedUpdate()
    {
        if (player_movement.Current_Control == true)
        {


            float angle = player_aim.angle;
            Vector3 mousePos = Input.mousePosition;
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

            

            if (mousePos.x < screenPoint.x)
            {
                //transform.localRotation = Quaternion.Euler(0, 180, 0);
                spriteRenderer.flipX = true;
            }
            else
            {
                //transform.localRotation = Quaternion.Euler(0, 0, 0);
                spriteRenderer.flipX = false;
            }


            if (angle < 22 && angle > -22)
            {
                //lado
                animator.SetInteger("AnimationState", 3);
            }
            else if (angle < 67 && angle > 22)
            {
                //diagonalCosta
                animator.SetInteger("AnimationState", 4);
            }
            else if (angle < -22 && angle > -60)
            {
                //diagonal
                animator.SetInteger("AnimationState", 2);
            }
            else if (angle < -50 && angle > -115)
            {
                //frente
                animator.SetInteger("AnimationState", 1);
            }
            else if (angle > 67 && angle < 112)
            {
                //costa
                animator.SetInteger("AnimationState", 5);
            }
            else if (angle > 112 && angle < 157)
            {
                //diagonalCosta
                animator.SetInteger("AnimationState", 4);
            }
            else if (angle > 157)
            {
                //lado
                animator.SetInteger("AnimationState", 3);
            }
            else if (angle > -180 && angle < -158)
            {
                //lado
                animator.SetInteger("AnimationState", 3);
            }
            else if (angle > -158 && angle < -113)
            {
                //diagonal
                animator.SetInteger("AnimationState", 2);
            }
        }
        else
        {
            // Handle animations when player_movement.Current_Control is false
        }
    }
}

