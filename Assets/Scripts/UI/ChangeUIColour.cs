using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUIColour : MonoBehaviour
{

    public Image ArcherSlot;
    public Image CannonSlot;
    public Image MagicSlot;

    public Color CantUseButton = Color.red;
    public Color CanUseButton = Color.green;

    private void Update()
    {
        if (Gold.instance.GoldAmount < 500)
        {
            MagicSlot.color = CantUseButton;

            if (Gold.instance.GoldAmount < 300)
            {
                CannonSlot.color = CantUseButton;

                if (Gold.instance.GoldAmount < 200)
                {
                    ArcherSlot.color = CantUseButton;
                }
            }
        }
        if (Gold.instance.GoldAmount >= 200)
        {
            ArcherSlot.color = CanUseButton;

            if (Gold.instance.GoldAmount >= 300)
            {
                CannonSlot.color = CanUseButton;

                if (Gold.instance.GoldAmount >= 500)
                {
                    MagicSlot.color = CanUseButton;
                }
            }
        }         
    }
}
