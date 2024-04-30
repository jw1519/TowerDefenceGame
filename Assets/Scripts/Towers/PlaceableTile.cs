using UnityEngine;

public class PlaceableTile : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 TowerOffset;

    public UITest UITest;

    [HideInInspector]
    public GameObject tower;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    public AudioSource CantDoThat;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseDown()
    {
        if (UITest.IsOverPannel == false)
        {
            if (tower != null)// stops towers on towers add upgrades appear instead
            {
                BuildManager.instance.SelectTower(this);
                return;
                
            }
            GameObject Tower = BuildManager.instance.GetTowerToBuild();

            if (Tower != BuildManager.instance.noTower)
            {
                tower = Instantiate(Tower, transform.position + TowerOffset, transform.rotation);
                Transform towerTransform = tower.transform;
                towerTransform.SetParent(transform);

                BuildManager.instance.SetNoTower();
            }
            else
                PlayAudio();
        }
        else
            return;
    }

    // when hoving over a tile
    void OnMouseEnter()
    {
        if (UITest.IsOverPannel == false)
            rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
       rend.material.color = startColor;
    }

    private void PlayAudio()
    {
      if (UITest.IsOverPannel == false)
         if (CantDoThat != null)
             CantDoThat.Play();
    }


    public void UpgradeTower() // tower swaps with an upgraded version can only happen once so far
    {
        GameObject child = transform.GetChild(0).gameObject;
        if (child.CompareTag("ArcherTower")) 
            BuildManager.instance.GetUpgradedArcher();
        if (child.CompareTag("CannonTower"))
            BuildManager.instance.GetUpgradedCannon();
        if (child.CompareTag("MagicTower"))
            BuildManager.instance.GetUpgradedMagic();

        Destroy(transform.GetChild(0).gameObject);

        GameObject Tower = BuildManager.instance.GetTowerToBuild();
        if (Tower != BuildManager.instance.noTower)
        {
            tower = Instantiate(Tower, transform.position + TowerOffset, transform.rotation);
            Transform towerTransform = tower.transform;
            towerTransform.SetParent(transform);

            BuildManager.instance.SetNoTower();
        }
        isUpgraded = true;
    }
    public void SellTower()
    {
        Destroy(transform.GetChild(0).gameObject);
    }
}
