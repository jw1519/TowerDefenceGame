using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerUprgades : MonoBehaviour
{
    public GameObject ui;
    public GameObject towerStats;
    public TextMeshProUGUI towerPower;
    public TextMeshProUGUI towerRange;
    public TextMeshProUGUI towerFirerate;

    public static TowerUprgades instance;

    private void Awake()
    {
        instance = this;
    }
    private PlaceableTile targetTile;
    private Towers targetTowerStats;
    private string TowerName;

    public void SetTarget(PlaceableTile target)
    {
        targetTile = target;

        transform.position = target.transform.position;

        ui.SetActive(true);
        towerStats.SetActive(true);
        targetTowerStats = target.GetComponentInChildren<Towers>();
        towerPower.SetText($"Power- {targetTowerStats.Damage}");
        towerRange.SetText($"Range- {targetTowerStats.Range}");
        towerFirerate.SetText($"fireRate- {targetTowerStats.fireRate}");

    }
    public void HideUI()
    {
        ui.SetActive(false);
        towerStats.SetActive(false);
    }
    public void Upgrade()
    {
        if (targetTile.isUpgraded != true) 
        { 
            if (Gold.instance.GoldAmount >= 200)
            {
                targetTile.UpgradeTower();
                BuildManager.instance.DeselectTower();
                Gold.instance.GoldAmount -= 200;
            }
            Debug.Log("not enough gold");
        }
        
    }

    public void sell()
    {
        targetTile.SellTower();
        BuildManager.instance.DeselectTower();
        Gold.instance.GoldAmount += 100;
        Gold.instance.UpdateGold();
    }
}
