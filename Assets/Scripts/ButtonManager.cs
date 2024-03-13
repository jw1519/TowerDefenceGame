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
    public Transform EnemiesList;

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
    public void OnDoubleDamageButtonPress()
    {
        //Towers do double damage for 10 sec


    }
    public void OnFreezeButtonPressed()
    {
        EnemiesList.transform.position = EnemiesList.transform.position;
        //Enemy Freeze for 10sec
        //Freeze = EnemyNavigation.instance


    }
}
