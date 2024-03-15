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
}
