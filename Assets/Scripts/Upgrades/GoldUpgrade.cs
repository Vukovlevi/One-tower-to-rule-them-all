using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GoldUpgrade : MonoBehaviour
{
    public struct Cost
    {
        public int woods;
        public int stones;
        public int golds;
    }

    public GameObject stoneGenerator;
    public GameObject woodGenerator;
    public GameObject UI;
    public GameObject inventory;
    public Button buyUpgradeBtn;
    public Text costText;
    public Text levelText;
    public Text errorText;
    private Cost cost;
    private bool UIActive = false;
    public int level = 1;
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
        stoneGenerator.GetComponent<StoneUpgrade>().turnOffUI();
        woodGenerator.GetComponent<WoodUpgrade>().turnOffUI();
        toggleUI();
    }

    public void turnOffUI()
    {
        UI.SetActive(false);
        UIActive = false;
        buyUpgradeBtn.gameObject.SetActive(false);
        errorText.enabled = false;
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
                cost.woods = 4;
                cost.stones = 4;
                cost.golds = 6;
                break;
            case 2:
                cost.woods = 10;
                cost.stones = 10;
                cost.golds = 8;
                break;
            case 3:
                break;
        }
    }

    private void showCost(Cost currentCost)
    {
        levelText.text = "Szint: " + level.ToString();
        if (level == 3)
        {
            costText.text = "A legmagasabb szintű az épület!";
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
        this.GetComponentInParent<GoldGenerator>().UpgradeToLevel(level);
        toggleUI();
    }
}
