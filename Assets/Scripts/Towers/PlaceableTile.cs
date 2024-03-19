using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceableTile : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 TowerOffset;

    public UITest UITest;

    [HideInInspector]
    public GameObject tower;
    [HideInInspector]
    public bool isUpgraded = false;
    [HideInInspector]
    public Towers towerblueprint;

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

    public void UpgradeTower()
    {
        GameObject Tower = BuildManager.instance.GetTowerToBuild();

        if (Tower != BuildManager.instance.noTower)
        {
            //destroy old turret
            Destroy(tower);

            tower = (GameObject)Instantiate(Tower, transform.position + TowerOffset, transform.rotation);
            BuildManager.instance.SetNoTower();
        }
        isUpgraded = true;
    }
}
