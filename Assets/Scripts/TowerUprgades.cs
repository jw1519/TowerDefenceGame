using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUprgades : MonoBehaviour
{
    public GameObject ui;
    public static TowerUprgades instance;
    private Transform child;

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
        if (Gold.instance.GoldAmount >= 0)
        {
            child = GetComponentInChildren<Transform>();
            Destroy(child);
            targetTile.UpgradeTower();
            BuildManager.instance.DeselectTower();
            //Gold.instance.GoldAmount -= 200;
        }
    }

    public void sell()
    {

        BuildManager.instance.DeselectTower();
        //Gold.instance.GoldAmount += 100;
    }
}
