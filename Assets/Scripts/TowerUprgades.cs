using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUprgades : MonoBehaviour
{
    public GameObject ui;
    public static TowerUprgades instance;

    private void Awake()
    {
        instance = this;
    }
    private PlaceableTile targetTile;

    public void SetTarget(PlaceableTile target)
    {
        targetTile = target;

        transform.position = target.transform.position;

        ui.SetActive(true);
    }
    public void HideUI()
    {
        ui.SetActive(false);
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
