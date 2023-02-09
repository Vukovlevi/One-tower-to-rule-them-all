using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoneUpgrade : MonoBehaviour
{
    public struct Cost
    {
        public int woods;
        public int stones;
        public int golds;
    }

    public GameObject UI;
    public GameObject inventory;
    public Button buyUpgradeBtn;
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
            buyUpgradeBtn.gameObject.SetActive(true);
            decideCost();
            showCost(cost);
        }
        else
        {
            UI.SetActive(false);
            UIActive = false;
            buyUpgradeBtn.gameObject.SetActive(false);
            errorText.enabled = false;
        }
    }

    private void decideCost()
    {
        switch(level)
        {
            case 1:
                cost.woods = 0;
                cost.stones = 4;
                cost.golds = 4;
                break;
            case 2:
                cost.woods = 6;
                cost.stones = 8;
                cost.golds = 6;
                break;
            case 3:
                break;
        }
    }

    private void showCost(Cost currentCost)
    {
        if (level == 3)
        {
            errorText.text = "A legmagasabb szintű az épület!";
            errorText.enabled = true;
            levelText.text = "Szint: " + level.ToString();
            return;
        }
        string costString = "A következő fejlesztés ára:\n";
        if (currentCost.woods != 0)
        {
            costString += currentCost.woods.ToString() + " fa, ";
        }
        if (currentCost.stones != 0)
        {
            costString += currentCost.stones.ToString() + " kő, ";
        }
        costString += currentCost.golds.ToString() + " arany";
        costText.text = costString;
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
        if (woodCount < cost.woods || stoneCount < cost.stones || goldCount < cost.golds)
        {
            errorText.text = "Nincs elegendő nyersanyagod a fejlesztéshez!";
            errorText.enabled = true;
            return;
        }
        level++;
        this.GetComponentInParent<StoneGenerator>().UpgradeToLevel(level);
        toggleUI();
    }
}
