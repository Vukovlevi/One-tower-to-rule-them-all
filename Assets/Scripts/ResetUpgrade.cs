using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetUpgrade : MonoBehaviour
{
    public GameObject woodGenerator;
    public GameObject stoneGenerator;
    public GameObject goldGenerator;
    public GameObject[] towers;
    // Start is called before the first frame update
    void Start()
    {
        towers = GameObject.FindGameObjectsWithTag("Tower");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnOffAllUI()
    {
        woodGenerator.GetComponent<WoodUpgrade>().turnOffUI();
        stoneGenerator.GetComponent<StoneUpgrade>().turnOffUI();
        goldGenerator.GetComponent<GoldUpgrade>().turnOffUI();
        foreach (GameObject tower in towers)
        {
            tower.GetComponent<TowerUpgrade>().turnOffUI();
        }
    }
}
