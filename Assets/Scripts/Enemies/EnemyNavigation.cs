using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public GameObject[] paths;
    public NavMeshAgent Enemy;
    public Animator animator;
    private int startingPath = 0;
    private int pathLength = 0;
    public int Health = 100;

    // Start is called before the first frame update
    void Start()
    {
        startingPath = 0;
        pathLength = paths.Length;
        Enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startingPath < pathLength)
        {
            if (Vector3.Distance(paths[startingPath].transform.position, gameObject.transform.position) < 1)
            {
                if (startingPath == pathLength - 1)
                {
                    startingPath = 0;
                }
                else
                {
                    startingPath++;
                }
            }
        }

        Enemy.SetDestination(paths[startingPath].transform.position);
        if (animator != null)
        {
            
        }

        
    }
    public void OnTriggerEnter(Collider other)
    {
        Health--;
    }
}
