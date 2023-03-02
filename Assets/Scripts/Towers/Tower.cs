using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Tower : MonoBehaviour
{
    public AudioSource audioData;
    private Vector3 projectileShootFrom;
    public GameObject projectileArrow;
    public GameObject target;
    public GameObject inventory;
    public float timeBetweenShots = 1.5f;
    public float timeSinceLastShot = 0;
    public float range = 15f;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot -= Time.deltaTime;

        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesArray.Length > 0 && timeSinceLastShot <= 0)
        {
            target = getClosestEnemy(enemiesArray);
            if ((target.transform.position - transform.position).sqrMagnitude <= range)
            {
                timeSinceLastShot = timeBetweenShots;
                audioData.Play(0);
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

    public void UpgradeToLevel(int level)
    {
        switch (level)
        {
            case 2:
                inventory.GetComponent<Inventory>().removeItem("Log", 4);
                inventory.GetComponent<Inventory>().removeItem("Stone", 2);
                inventory.GetComponent<Inventory>().removeItem("Gold", 1);
                timeBetweenShots = 0.5f; // TODO: �les sz�mokra cser�lni
                break;
            case 3:
                inventory.GetComponent<Inventory>().removeItem("Log", 6);
                inventory.GetComponent<Inventory>().removeItem("Stone", 3);
                inventory.GetComponent<Inventory>().removeItem("Gold", 2);
                range = 20f;
                timeBetweenShots = 0.4f;
                break;
        }
    }
}
