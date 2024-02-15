using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public static Gold instance;

    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        EnemyNavigation.instance.IncreaseGold();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
