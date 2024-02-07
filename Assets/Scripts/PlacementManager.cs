using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffSet;

    private GameObject archerTower;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseDown()
    {
        if (archerTower != null)
        {
            Debug.Log("Cant build there!");
            return;
        }

        //build tower
        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
        archerTower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffSet, transform.rotation);
    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
