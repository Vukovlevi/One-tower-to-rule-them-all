using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1 : MonoBehaviour
{
    public GameObject mainTower;
    public float speed;
    private Waypoints1 Wpoints1;
    private int waypointIndex1;

    private void Start()
    {
        Wpoints1 = GameObject.FindGameObjectWithTag("Waypoints1").GetComponent<Waypoints1>();
        mainTower = GameObject.Find("Main tower");
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Wpoints1.waypoints1[waypointIndex1].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, Wpoints1.waypoints1[waypointIndex1].position) < 0.1f)
        {
            waypointIndex1++;
            if (waypointIndex1 < Wpoints1.waypoints1.Length - 1)
            {
                waypointIndex1++;
            }
            else
            {
                mainTower.GetComponent<GameOver>().gameOver();
            }
        }
    }
}
