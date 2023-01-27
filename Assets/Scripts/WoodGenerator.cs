using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodGenerator : MonoBehaviour
{
    public int timeBetweenWoods = 5; // in seconds, just for test purposes, in prod it will be more
    public float timeSinceLastWood = 5f;
    public Item item;
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastWood <= 0)
        {
            inventory.GetComponent<Inventory>().AddItem(item);
            timeSinceLastWood = timeBetweenWoods;
        }
        else
        {
            timeSinceLastWood -= Time.deltaTime;
        }
    }

    public void UpgradeToLevel(int level)
    {
        switch(level)
        {
            case 2:
                inventory.GetComponent<Inventory>().removeItem("Log", 10);
                inventory.GetComponent<Inventory>().removeItem("Gold", 3);
                timeBetweenWoods = 3; // TODO: �les sz�mokra cser�lni
                break;
            case 3:
                inventory.GetComponent<Inventory>().removeItem("Log", 15);
                inventory.GetComponent<Inventory>().removeItem("Stone", 3);
                inventory.GetComponent<Inventory>().removeItem("Gold", 5);
                timeBetweenWoods = 1;
                break;
        }
    }
}
