using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform pfEnemy1;
    public float timeBetweenSpawns = 20f;
    public float timeSinceLastSpawn = 20f;
    public float timebetweenwaves = 60f;
    public float countdown= 60f;
    private int wavenumber = 1;

    // Start is called before the first frame update
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
        if (countdown <= 0)
        {
            StartCoroutine(Spawnwave());
            countdown = timebetweenwaves;
        }
        else
        {
            countdown -= Time.deltaTime;
        }
    }
    IEnumerator Spawnwave()
    {
        for (int i=0; i <wavenumber; i++)
        {
            SpawnEnemy1();
            yield return new WaitForSeconds(0.5f);
        }
        wavenumber++;
    }
    public void SpawnEnemy1()
    {
        Instantiate(pfEnemy1, transform.position, Quaternion.identity);
    }
}
