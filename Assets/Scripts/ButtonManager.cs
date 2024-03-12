using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject upgradesPannel;
    public GameObject towerPannel;

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

            powerUpgradeCost += 200;
        }
        
    }
    public void UpgradeRange()
    {
        if (Gold.instance.GoldAmount >= RangeUpgradeCost)
        {

        }
    }
}
