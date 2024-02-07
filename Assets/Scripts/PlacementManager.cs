using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 ArcherTowerOffSet;
    public Vector3 cannonTowerOffSet;
    public Vector3 magicTowerOffSet;

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

        if (tower != null)// stops towers on towers
        {
            Debug.Log("Cant build there!");
            return;
        }
        GameObject archerTower = BuildManager.instance.GetTowerToBuild();
        //build tower
        if (tower.CompareTag(""))
        {

        }
        if (tower.CompareTag(""))
        {

        }
        if (tower.CompareTag(""))
        {

        }

        tower = (GameObject)Instantiate(archerTower, transform.position + ArcherTowerOffSet, transform.rotation);
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
