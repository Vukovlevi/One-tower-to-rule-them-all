using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character4 : MonoBehaviour
{
    public float speed;
    private Waypoints4 Wpoints4;
    private int waypointIndex4;

    private void Start()
    {
        Wpoints4 = GameObject.FindGameObjectWithTag("Waypoints4").GetComponent<Waypoints4>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Wpoints4.waypoints4[waypointIndex4].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, Wpoints4.waypoints4[waypointIndex4].position) < 0.1f)
        {
            waypointIndex4++;
            if (waypointIndex4 < Wpoints4.waypoints4.Length - 1)
            {
                waypointIndex4++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
