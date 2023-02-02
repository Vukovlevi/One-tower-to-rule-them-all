using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGenerator : MonoBehaviour
{
    public int timeBetweenGolds = 60; // in seconds, just for test purposes, in prod it will be more
    public float timeSinceLastGold = 60f;
    public Item item;
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastGold <= 0)
        {
            inventory.GetComponent<Inventory>().AddItem(item);
            timeSinceLastGold = timeBetweenGolds;
        }
        else
        {
            timeSinceLastGold -= Time.deltaTime;
        }
    }

public void UpgradeToLevel(int level)
    {
        switch(level)
        {
            case 2:
                inventory.GetComponent<Inventory>().removeItem("Log", 4);
                inventory.GetComponent<Inventory>().removeItem("Stone", 4);
                inventory.GetComponent<Inventory>().removeItem("Gold", 6);
                timeBetweenGolds = 10; // TODO: �les sz�mokra cser�lni
                break;
            case 3:
                inventory.GetComponent<Inventory>().removeItem("Log", 10);
                inventory.GetComponent<Inventory>().removeItem("Stone", 10);
                inventory.GetComponent<Inventory>().removeItem("Gold", 8);
                timeBetweenGolds = 5;
                break;
        }
    }
}
