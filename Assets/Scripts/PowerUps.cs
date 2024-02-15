using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public void OnDoubleDamageButtonPress()
    {
        Debug.Log("press");
        //Towers do double damage for 10 sec
    }
    public void OnFreezeBottonPressed()
    {
        //Enemy Freeze for 10sec
        //Freeze = EnemyNavigation.instance
    }
}
