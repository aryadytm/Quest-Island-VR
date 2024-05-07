using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float moveRangeA = 0.0f;
    public float moveRangeB = 10.0f;
    public Vector3 moveDirection = Vector3.right; // Default move direction along X-axis

    private Vector3 startPosition;
    private bool movingTowardsA = true;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame 
    void Update()
    {
        MovingTarget();
    }

    private void MovingTarget()
    {
        Vector3 targetPositionA = startPosition + moveDirection * moveRangeA;
        Vector3 targetPositionB = startPosition + moveDirection * moveRangeB;
        Vector3 targetPosition = movingTowardsA ? targetPositionA : targetPositionB;
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            movingTowardsA = !movingTowardsA;
        }
    }
}
