using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowertSelectionManager : MonoBehaviour
{
    public static TowertSelectionManager instance;

    private void Awake()
    {
        instance = this;
    }

    private bool isTowerSelected;
    private SelectableObject selectedTower;

    public void SelectTower(SelectableObject tower)
    {
        if (selectedTower != null)
        {
            selectedTower.Deselect();
        }
        selectedTower = tower;
        selectedTower.Select();
    }
    public void DeselectTower()
    {

    }
}
