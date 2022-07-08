using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    [SerializeField] bool isSeeker;
    
    GameObject target;
    Mover mover;
    SearchForEnemies searchForEnemies;

    private void Awake()
    {
        mover = GetComponent<Mover>();
        searchForEnemies = GetComponent<SearchForEnemies>();
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
        target = searchForEnemies.GetTarget();
        if(target == null) { return; }

        Vector3 targetDirection = GetTargetDirection(target.transform);

        if (!isSeeker) 
        {
            mover.UpdateMovementData(targetDirection);
        }
        else
        {
            mover.UpdateMovementData(GetTargetDirection(target.transform));
        }
    }
}
