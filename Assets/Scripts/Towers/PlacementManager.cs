using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementManager : MonoBehaviour
{
    public float opacity = 0.5f;
    public Color hoverColor;
    public Vector3 TowerOffset;
    public GameObject upgradesPannel;
    public GameObject towerPannel;

    public UITest UITest;

    private GameObject tower;

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
                towerPannel.SetActive(false);
                upgradesPannel.SetActive(true);
                return;
            }

            GameObject Tower = BuildManager.instance.GetTowerToBuild();

            if (Tower != BuildManager.instance.noTower)
            {
                tower = (GameObject)Instantiate(Tower, transform.position + TowerOffset, transform.rotation);
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
        GameObject Tower = BuildManager.instance.GetTowerToBuild();
        Renderer renderer = Tower.GetComponent<Renderer>();

        if (UITest.IsOverPannel == false)
             rend.material.color = hoverColor;
        //have a tower appear when hover
        //if (Tower != BuildManager.instance.noTower)
        //{
        //    if (renderer != null && renderer.material != null)
        //    {
        //        Color color = renderer.sharedMaterial.color;
        //        color.a = opacity;
        //        renderer.material.color = color;
        //    }
        //}
    }
    private void OnMouseExit()
    {
       rend.material.color = startColor;
    }

    private void PlayAudio()
    {
        if (CantDoThat != null)
            CantDoThat.Play();
    }
}
