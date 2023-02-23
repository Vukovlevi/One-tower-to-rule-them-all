using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2 : MonoBehaviour
{
    public GameObject mainTower;
    public float speed;
    private Waypoints2 Wpoints2;
    private int waypointIndex2;

    private void Start()
    {
        Wpoints2 = GameObject.FindGameObjectWithTag("Waypoints2").GetComponent<Waypoints2>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Wpoints2.waypoints2[waypointIndex2].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, Wpoints2.waypoints2[waypointIndex2].position) < 0.1f)
        {
            waypointIndex2++;
            if (waypointIndex2 < Wpoints2.waypoints2.Length - 1)
            {
                waypointIndex2++;
            }
            else
            {
                mainTower.GetComponent<GameOver>().gameOver();
            }
        }
    }
}
