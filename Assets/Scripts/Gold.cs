using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public static Gold instance;

    private int GoldAmount = 200;

    void Awake()
    {
        instance = this;
    }

    public void IncreaseGold()
    {
        GoldAmount = GoldAmount + 10;
        goldText.SetText("Gold: " + GoldAmount);
    }
    public void DecreaseGold()
    {
        GoldAmount = GoldAmount - 10;
        goldText.SetText("Gold: " + GoldAmount);
    }
}
