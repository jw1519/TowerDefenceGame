using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverButtonManager : MonoBehaviour
{
    public TextMeshProUGUI GoldText;

    private void Start()
    {
        GoldText.SetText("Total Gold Accumulated " + Gold.TotalGoldEarned);
    }
}
