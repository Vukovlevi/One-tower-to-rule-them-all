using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character3 : MonoBehaviour
{
    public GameObject mainTower;
    public float speed;
    private Waypoints3 Wpoints3;
    private int waypointIndex3;

    private void Start()
    {
        Wpoints3 = GameObject.FindGameObjectWithTag("Waypoints3").GetComponent<Waypoints3>();
        mainTower = GameObject.Find("Main tower");
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Wpoints3.waypoints3[waypointIndex3].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, Wpoints3.waypoints3[waypointIndex3].position) < 0.1f)
        {
            waypointIndex3++;
            if (waypointIndex3 < Wpoints3.waypoints3.Length - 1)
            {
                waypointIndex3++;
            }
            else
            {
                mainTower.GetComponent<GameOver>().gameOver();
            }
        }
    }
}
