using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 10.0f;
    [SerializeField] private LayerMask enemyLayer;

    public GameObject GetClosedEnemy()
    {
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        if(enemiesInRange.Length > 0 )
        {
            GameObject bestTarget = null;
            float closestDistanceSqr = Mathf.Infinity;
            Vector3 currentPostion = transform.position;

            foreach(Collider enemyCollider in enemiesInRange)
            {
                if(enemyCollider.gameObject == this)
                    continue;
                Vector3 directionToTarget = enemyCollider.transform.position - currentPostion;
                float dSqrToTarger = directionToTarget.sqrMagnitude;

                if(dSqrToTarger < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarger;
                    bestTarget = enemyCollider.gameObject;
                }
            }
            return bestTarget;
        }
        else
        {
            return null;
        }
    }

    public List<GameObject> GetEnemiesInRange()
    {
        List<GameObject> enemiesList = new List<GameObject>();
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        foreach(Collider enemyCollider in enemiesInRange)
        {
            if(enemyCollider.gameObject != this.gameObject)
            {
                enemiesList.Add(enemyCollider.gameObject);
            }
        }
        return enemiesList;
    }
}
