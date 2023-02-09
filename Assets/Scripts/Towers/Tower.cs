using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private Vector3 projectileShootFrom;
    public GameObject projectileArrow;
    public GameObject target;
    public int timeBetweenShots = 3;
    public float timeSinceLastShot = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot -= Time.deltaTime;
        if (Input.GetMouseButtonDown(1))
        {
            projectileArrow.GetComponent<ProjectileArrow>().Create(projectileShootFrom, target);
        }

        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesArray.Length > 0)
        {
            target = getClosestEnemy(enemiesArray);
            if ((target.transform.position - transform.position).sqrMagnitude <= 15f && timeSinceLastShot <= 0)
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
        Vector3 currentPosition = transform.position;
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
