using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideTower : MonoBehaviour
{
    public GameObject currentTower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decideTower(GameObject tower)
    {
        currentTower = tower;
    }

    public void upgradeTower()
    {
        currentTower.GetComponent<TowerUpgrade>().upgrade();
    }
}
