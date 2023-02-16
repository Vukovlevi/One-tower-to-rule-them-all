using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private Vector3 projectileShootFrom;
    public GameObject projectileArrow;
    public GameObject target;
    public float timeBetweenShots = 1.5f;
    public float timeSinceLastShot = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot -= Time.deltaTime;

        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesArray.Length > 0 && timeSinceLastShot <= 0)
        {
            target = getClosestEnemy(enemiesArray);
            if ((target.transform.position - transform.position).sqrMagnitude <= 10f)
            {
                timeSinceLastShot = timeBetweenShots;
                projectileArrow.GetComponent<ProjectileArrow>().Create(projectileShootFrom, target);
            }       
        }
    }

    private void Awake()
    {
        projectileShootFrom = transform.Find("ProjectileShootFrom").position;
    }

    public GameObject getClosestEnemy(GameObject[] enemies)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = gameObject.transform.position;
        foreach (GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
}
