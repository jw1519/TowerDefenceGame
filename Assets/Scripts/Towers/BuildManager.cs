using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance; // used in PlacementManager

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("more than one gamemanager");

        instance = this;
    }

    [HideInInspector]public GameObject towerToBuild;

    [Header ("Towers")]
    public GameObject archerTower;
    public GameObject cannonTower;
    public GameObject magicTower;
    public GameObject noTower;

    [Header("Upgraded Towers")]
    public GameObject UpgradedArcherTower;
    public GameObject UpgradedCannonTower;
    public GameObject UpgradedMagicTower;

    private PlaceableTile selectedTower;
    public TowerUprgades tileUI;


    private void Start()
    {
        SetNoTower();
    }
    public GameObject GetTowerToBuild()
    {
        TowerUprgades.instance.HideUI();
        return towerToBuild;
    }
    public void GetArcherTower()
    {
        if (Gold.instance.GoldAmount >= 200)
        {
            towerToBuild = archerTower;
            Gold.instance.DecreaseGold();
        }
    }
    public void GetCannonTower()
    {
        if (Gold.instance.GoldAmount >= 300)
        {
            towerToBuild = cannonTower;
            Gold.instance.DecreaseGold();
        }
    }
    public void GetMagicTower()
    {
        if (Gold.instance.GoldAmount >= 500)
        {
            towerToBuild = magicTower;
            Gold.instance.DecreaseGold();
        }
    }
    public void SetNoTower()
    {
        towerToBuild = noTower;
        selectedTower = null;
        
    }
    public void SelectTower(PlaceableTile Tile) 
    {
        if (selectedTower == Tile)
        {
            DeselectTower();
            return;
        }
        selectedTower = Tile;
        towerToBuild = noTower;
        tileUI.SetTarget(Tile);
    }

    public void DeselectTower()
    {
        selectedTower = null;
        TowerUprgades.instance.HideUI();
    }

    public void GetUpgradedArcher()
    {
        towerToBuild = UpgradedArcherTower;
    }
    public void GetUpgradedCannon()
    {
        towerToBuild = UpgradedCannonTower;
    }
    public void GetUpgradedMagic()
    {
        towerToBuild = UpgradedMagicTower;
    }
}
