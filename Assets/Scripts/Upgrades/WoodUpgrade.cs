using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WoodUpgrade : MonoBehaviour
{
    public struct Cost
    {
        public int woods;
        public int stones;
        public int golds;
    }

    public GameObject UI;
    public GameObject inventory;
    public Text costText;
    public Text levelText;
    public Text errorText;
    private Cost cost;
    private bool UIActive = false;
    private int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        toggleUI();
    }

    private void toggleUI()
    {
        if (!UIActive)
        {
            UI.SetActive(true);
            UIActive = true;
            decideCost();
            showCost(cost);
        }
        else
        {
            UI.SetActive(false);
            UIActive = false;
            errorText.enabled = false;
        }
    }

    private void decideCost()
    {
        switch(level)
        {
            case 1:
                cost.woods = 10;
                cost.stones = 0;
                cost.golds = 3;
                break;
            case 2:
                cost.woods = 15;
                cost.stones = 3;
                cost.golds = 5;
                break;
            case 3:
                break;
        }
    }

    private void showCost(Cost currentCost)
    {
        if (level == 3)
        {
            errorText.text = "A legmagasabb szintû az épület!";
            errorText.enabled = true;
            return;
        }
        levelText.text = "Szint: " + level.ToString();
        string costString = "A következõ fejlesztés ára:\n";
        if (currentCost.woods != 0)
        {
            costString += currentCost.woods.ToString() + " fa, ";
        }
        if (currentCost.stones != 0)
        {
            costString += currentCost.stones.ToString() + " kõ, ";
        }
        costString += currentCost.golds.ToString() + " arany";
        costText.text = costString;
        Debug.Log(cost.woods);
    }

    public void Upgrade()
    {
        if (level == 3)
        {
            return;
        }
        int woodCount = inventory.GetComponent<Inventory>().CountItem("Log");
        int stoneCount = inventory.GetComponent<Inventory>().CountItem("Stone");
        int goldCount = inventory.GetComponent<Inventory>().CountItem("Gold");
        Debug.Log(woodCount);
        Debug.Log(cost.woods);
        if (woodCount < cost.woods || stoneCount < cost.stones || goldCount < cost.golds)
        {
            errorText.text = "Nincs elegendõ nyersanyagod a fejlesztéshez!";
            errorText.enabled = true;
            return;
        }
        level++;
        this.GetComponentInParent<WoodGenerator>().UpgradeToLevel(level);
        toggleUI();
    }
}
