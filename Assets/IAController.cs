using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    Transform PlayerTransform;
    Mover mover;

    private void Awake()
    {
        PlayerTransform = GameObject.FindWithTag("Player").transform;
        mover = GetComponent<Mover>();
    }

    void FixedUpdate()
    {
        UpdateMovement();
    }

    private Vector3 GetTargetDirection(Transform target)
    {
        return (target.transform.position - transform.position).normalized;
    }

    void UpdateMovement()
    {
        mover.UpdateMovementData(GetTargetDirection(PlayerTransform));
    }
}
