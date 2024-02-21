using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementManager : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 TowerOffset;
    public GameObject upgradesPannel;
    public GameObject towerPannel;

    private GameObject tower;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseDown()
    {

        if (tower != null)// stops towers on towers add upgrades appear instead
        {
            towerPannel.SetActive(false);
            upgradesPannel.SetActive(true);
            return;
        }
        
        GameObject archerTower = BuildManager.instance.GetTowerToBuild();
        tower = (GameObject)Instantiate(archerTower, transform.position + TowerOffset, transform.rotation);
    }


    // when hoving over a tile
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
