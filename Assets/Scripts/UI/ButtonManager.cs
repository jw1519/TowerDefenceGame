using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ButtonManager : MonoBehaviour
{
    public GameObject ParentObject;
    public void OnDoubleDamageButtonPress()
    {
        if (Gold.instance.GoldAmount >= 100)
        {
            Gold.instance.GoldAmount -= 100;
            EnemyNavigation[] children = ParentObject.GetComponentsInChildren<EnemyNavigation>();
            foreach (EnemyNavigation child in children)
            {
                StartCoroutine(child.DoubleDamageDuration());
            }
        }
    }
    public void OnFreezeButtonPressed()
    {
        if (Gold.instance.GoldAmount >= 50)
            StartCoroutine(FreezeEnemiesForDuration());
    }
    IEnumerator FreezeEnemiesForDuration()
    {
        Gold.instance.GoldAmount -= 50;
        Transform[] children = ParentObject.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            NavMeshAgent navMeshAgent = child.GetComponent<NavMeshAgent>();  
            Animator animator = child.GetComponent<Animator>();
            if (navMeshAgent != null)
            {
                navMeshAgent.enabled = false;
                animator.enabled = false;
            }
        }
        yield return new WaitForSeconds(10f);
        foreach (Transform child in children)
        {
            NavMeshAgent navMeshAgent = child.GetComponent<NavMeshAgent>();
            Animator animator = child.GetComponent<Animator>();
            if (navMeshAgent != null)
            {
                navMeshAgent.enabled = true;
                animator.enabled = true;

                EnemyNavigation NavigationScript = child.GetComponent<EnemyNavigation>();
                navMeshAgent.SetDestination(NavigationScript.navMeshDestination);
            }
        }
    }
}
