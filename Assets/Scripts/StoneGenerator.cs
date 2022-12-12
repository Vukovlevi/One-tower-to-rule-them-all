using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGenerator : MonoBehaviour
{
    public int timeBetweenStones = 15; // in seconds, just for test purposes, in prod it will be more
    public float timeSinceLastStone = 15f;
    public Item item;
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastStone <= 0)
        {
            inventory.GetComponent<Inventory>().AddItem(item);
            timeSinceLastStone = timeBetweenStones;
        }
        else
        {
            timeSinceLastStone -= Time.deltaTime;
        }
    }
}
