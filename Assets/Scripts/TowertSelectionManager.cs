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

    private SelectableObject selectedTower;

    public void SelectTower(SelectableObject tower)
    {
        if (instance != null)
        {
            SelectableObject.instance.Deselect();
        }
        //selecet tower
        SelectableObject.instance = tower;
        SelectableObject.instance.Select();
    }
    public void DeselectTower()
    {
        if (SelectableObject.instance != null)
        {
            SelectableObject.instance.Deselect();
            SelectableObject.instance = null;
        }
    }
}
