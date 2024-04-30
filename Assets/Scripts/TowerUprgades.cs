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
    private Transform grandchild;


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

        //shows the range
        Transform child = target.transform.GetChild(0);
        grandchild = child.transform.GetChild(1);
        grandchild.gameObject.SetActive(true);
    }
    public void HideUI()
    {
        ui.SetActive(false);
        towerStats.SetActive(false);
        if (grandchild != null)
                grandchild.gameObject.SetActive(false);
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
