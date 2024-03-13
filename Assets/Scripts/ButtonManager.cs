using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject upgradesPannel;
    public GameObject towerPannel;
    public TextMeshProUGUI PowerCostText;
    public TextMeshProUGUI RangeCostText;

    int powerUpgradeCost = 200;
    int RangeUpgradeCost = 100;
    public void CloseUpgradesPannel()
    {
        towerPannel.SetActive(true);
        upgradesPannel.SetActive(false);
    }
    public void SellTower()
    {

    }

    public void UpgradePower()
    {
        if (Gold.instance.GoldAmount >= powerUpgradeCost)
        {

            //Gold.instance.GoldAmount -= powerUpgradeCost;
            powerUpgradeCost += 200;
            PowerCostText.SetText($"Power- {powerUpgradeCost}");
        }
        
    }
    public void UpgradeRange()
    {
        if (Gold.instance.GoldAmount >= RangeUpgradeCost)
        {

            //Gold.instance.GoldAmount -= RangeUpgradeCost;
            RangeUpgradeCost += 100;
            RangeCostText.SetText($"Range- {RangeUpgradeCost}");
        }
    }
}
