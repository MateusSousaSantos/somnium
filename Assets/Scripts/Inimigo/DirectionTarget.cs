using UnityEngine;

public class MovementTracker : MonoBehaviour
{
    private Vector2 previousPosition;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Start()
    {
        previousPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 currentPosition = transform.position;
        string movementDirection = GetMovementDirection(currentPosition, previousPosition);

        // Update sprite flip based on movement direction
        if (movementDirection == "right")
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isWalking", true);
        }
        else if (movementDirection == "left")
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isWalking", true);
        }
        else if (movementDirection == "stationary")
        {
            animator.SetBool("isWalking", false);
        }

        previousPosition = currentPosition;
    }

    private string GetMovementDirection(Vector2 currentPos, Vector2 previousPos)
    {
        if (currentPos.x > previousPos.x)
        {
            return "right";
        }
        else if (currentPos.x < previousPos.x)
        {
            return "left";
        }
        else
        {
            return "stationary";
        }
    }


}
