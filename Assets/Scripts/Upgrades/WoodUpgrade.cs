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

    public SpriteRenderer spriteRenderer;
    public Sprite[] upgradeSprites;
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
        if (UI.activeSelf && !UIActive)
        {
            UI.GetComponent<ResetUpgrade>().turnOffAllUI();
        }
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
                cost.woods = 8;
                cost.stones = 0;
                cost.golds = 2;
                break;
            case 2:
                cost.woods = 12;
                cost.stones = 3;
                cost.golds = 3;
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
        spriteRenderer.sprite = upgradeSprites[level - 1];
        level++;
        this.GetComponentInParent<WoodGenerator>().UpgradeToLevel(level);
        toggleUI();
    }
}
