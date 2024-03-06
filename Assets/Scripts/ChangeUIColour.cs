using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeUIColour : MonoBehaviour
{
    public Image ArcherSlot;
    public Image CannonSlot;
    public Image MagicSlot;

    private void Awake()
    {

    }

    private void Update()
    {
        if (Gold.instance.GoldAmount < 500)
        {
            MagicSlot.tintColor = Color.red;

            if (Gold.instance.GoldAmount < 300)
            {
                CannonSlot.tintColor = Color.red;

                if (Gold.instance.GoldAmount < 200)
                {
                    ArcherSlot.tintColor = Color.red;
                }
            }
        }
    }
}
