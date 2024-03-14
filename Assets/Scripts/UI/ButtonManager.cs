using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ButtonManager : MonoBehaviour
{
    public GameObject upgradesPannel;
    public GameObject towerPannel;
    public TextMeshProUGUI PowerCostText;
    public TextMeshProUGUI RangeCostText;
    public GameObject[] EnemiesList;

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
        StartCoroutine(FreezeEnemiesForDuration());

    }
    IEnumerator FreezeEnemiesForDuration()
    {
        foreach (GameObject child in EnemiesList)
        {
            NavMeshAgent navMeshAgent = child.GetComponent<NavMeshAgent>();
            if (navMeshAgent != null)
            {
                navMeshAgent.enabled = false;
            }
            
        }
        yield return new WaitForSeconds(10f);
        foreach (GameObject child in EnemiesList)
        {
            NavMeshAgent navMeshAgent = child.GetComponent<NavMeshAgent>();
            if (navMeshAgent != null)
            {
                navMeshAgent.enabled = true;
            }

        }
    }
}
