using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableObject : MonoBehaviour
{
    private bool isSelected;
    public Material OriginalMaterial;
    private TowertSelectionManager selectionManager;

    public Material selectedMaterial;

    public static SelectableObject instance;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        selectionManager = FindObjectOfType<TowertSelectionManager>();
        if (selectionManager == null)
        {
            Debug.LogError("TowerSelectionManager instance is null.");
        }
    }

    private void OnMouseDown()
    {
       if (!isSelected)
        {
            TowertSelectionManager.instance.SelectTower(this);
        }
    }

    public void Select()
    {
        isSelected= true;
        GetComponent<Renderer>().material = selectedMaterial;
    }
    public void Deselect()
    {
        isSelected = false;
        GetComponent<Renderer>().material = OriginalMaterial;
    }
}
