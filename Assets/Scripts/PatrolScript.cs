using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PatrolScript : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;

    [SerializeField] Rigidbody2D rb;

    float speed = 2.0f;

    Transform currentPoint;

    private void Start()
    {
        currentPoint = pointA.transform; // Initialize the starting point
    }

    private void Update()
    {
        float point = Vector2.Distance(transform.position, currentPoint.position);

        if (point < 1f)
        {
            if (currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
            }
            else if (currentPoint == pointB.transform)
            {
                currentPoint = pointA.transform;
            }
        }

        // Move towards the current point
        Vector3 direction = (currentPoint.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }
}
