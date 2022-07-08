using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForEnemies : MonoBehaviour
{
    Transform enemyPooler;

    GameObject target;
    Mover mover;

    const string checkForEnemies = "CheckForEnemies";

    private void Awake()
    {
        mover = GetComponent<Mover>();
        enemyPooler = GameObject.FindWithTag("Enemies").transform;
    }

    void Start()
    {
        InvokeRepeating(checkForEnemies, 0f, 0.5f);
    }

    private void CheckForEnemies()
    {
        GameObject closestEnemy = null;
        float maxDistance = Mathf.Infinity;

        foreach (Transform enemy in enemyPooler)
        {
            if (!enemy.gameObject.activeSelf) { continue; }

            float distanceToTarget = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToTarget < maxDistance)
            {
                maxDistance = distanceToTarget;
                closestEnemy = enemy.gameObject;
            }
        }
        target = closestEnemy;
        //mover.SetTarget(target);
    }

    public GameObject GetTarget()
    {
        return target;
    }
}
