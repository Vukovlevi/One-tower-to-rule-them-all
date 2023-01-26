using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    private Waypoints Wpoints;
    private int waypointIndex;

    private void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;
            if(waypointIndex< Wpoints.waypoints.Length)
            {
                waypointIndex++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
