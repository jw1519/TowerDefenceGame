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
    public GameObject standardTowerPrefab;
    private void Start()
    {
        towerToBuild = standardTowerPrefab;
    }
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }


}
