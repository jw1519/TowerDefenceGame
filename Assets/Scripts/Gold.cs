using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public static Gold instance;

    public int GoldAmount = 200;

    void Awake()
    {
        instance = this;
    }

    public void IncreaseGold()
    {
        GoldAmount = GoldAmount + 10;
        goldText.SetText("Gold: " + GoldAmount);
    }
    public void DecreaseGold()
    {
        if (BuildManager.instance.towerToBuild == BuildManager.instance.archerTower)
        {
            GoldAmount = GoldAmount - 200;
            goldText.SetText("Gold: " + GoldAmount);
        }
        if (BuildManager.instance.towerToBuild == BuildManager.instance.cannonTower)
        {
            GoldAmount = GoldAmount - 300;
            goldText.SetText("Gold: " + GoldAmount);
        }
        if (BuildManager.instance.towerToBuild == BuildManager.instance.magicTower)
        {
            GoldAmount = GoldAmount - 500;
            goldText.SetText("Gold: " + GoldAmount);
        }

    }
}
