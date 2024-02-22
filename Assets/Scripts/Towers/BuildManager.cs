using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("more than one gamemanager");

        instance = this;
    }

    private GameObject towerToBuild;
    public GameObject archerTower;
    public GameObject cannonTower;
    public GameObject magicTower;


    private void Start()
    {
        towerToBuild = archerTower;
    }
    public GameObject GetTowerToBuild()
    {
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
        if (Gold.instance.GoldAmount >= 350)
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
}
