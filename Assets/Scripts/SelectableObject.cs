using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    private bool isSelected;
    public Material OriginalMaterial;
    private TowertSelectionManager selectionManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
       if (!isSelected)
        {
            selectionManager.SelectTower(this);
        }
    }

    public void Select()
    {
        isSelected= true;
    }
    public void Deselect()
    {
        isSelected = false;
    }
}
