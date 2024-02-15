using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public static Gold instance;

    private int GoldAmount = 0;

    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void IncreaseGold()
    {
        GoldAmount = GoldAmount + 10;
        goldText.SetText("Gold: " + GoldAmount);
    }
}
