using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject upgradesPannel;
    public GameObject towerPannel;
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
        
    }
    public void UpgradeRange()
    {

    }
}
