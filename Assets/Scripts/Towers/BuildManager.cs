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
        towerToBuild = archerTower;
    }
    public void GetCannonTower()
    {
        towerToBuild = cannonTower;
    }
    public void GetMagicTower()
    {
        towerToBuild = magicTower;
    }

}
