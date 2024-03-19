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
        Debug.Log("press");
        targetTile.UpgradeTower();
        BuildManager.instance.DeselectTower();
    }

    public void sell()
    {
        BuildManager.instance.DeselectTower();
    }
}
