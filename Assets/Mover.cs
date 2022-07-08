using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float movementSmoothingSpeed = 10f;
    [SerializeField] float groundPadding = 0.5f;
    
    Vector3 rawDirection;
    Vector3 smoothMovement;
    GameObject targetDirection;

    void FixedUpdate()
    {
        Move();
    }

    public void UpdateMovementData(Vector3 newRawDirection)
    {
        rawDirection = newRawDirection;
    }

    // public void SetTarget(GameObject target)
    // {
    //     targetDirection = target;
    // }

    void Move()
    {
        smoothMovement = Vector3.Lerp(smoothMovement, rawDirection, Time.fixedDeltaTime * movementSmoothingSpeed);
        Vector3 movement = smoothMovement * speed * Time.fixedDeltaTime;
        Vector3 clampedMovement = new Vector3(transform.position.x + movement.x, groundPadding, transform.position.z + movement.z);
        transform.position = clampedMovement;
    }
}
