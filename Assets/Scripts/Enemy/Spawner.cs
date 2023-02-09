using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform pfEnemy1;
    public int timeBetweenSpawns = 3;
    public float timeSinceLastSpawn = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastSpawn <= 0)
        {
            SpawnEnemy1();
            timeSinceLastSpawn = timeBetweenSpawns;
        }
        else
        {
            timeSinceLastSpawn -= Time.deltaTime;
        }
    }
    public void SpawnEnemy1()
    {
        Instantiate(pfEnemy1, transform.position, Quaternion.identity);
    }
}
