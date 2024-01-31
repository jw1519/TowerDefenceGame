using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Text;
using TMPro;

public class EnemyNavigation : MonoBehaviour
{
    public GameObject[] paths;
    Vector3 destination;
    public NavMeshAgent Enemy;
    public Animator animator;
    public Transform target;

    public TextMeshProUGUI Gold;
    public TextMeshProUGUI healthText;

    private int gold = 0;
    private int startingPath = 0;
    private int pathLength = 0;
    public int Health = 100;
    int isDyingHash;

    // Start is called before the first frame update
    void Start()
    {
        startingPath = 0;
        pathLength = paths.Length;
        Enemy = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isDyingHash = Animator.StringToHash("IsDying");

        destination = Enemy.destination;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(destination, target.position) > 1f)
        {
            destination = target.position;
            Enemy.destination = destination;
        }


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

            bool IsDying = animator.GetBool(isDyingHash);
        }

        Enemy.SetDestination(paths[startingPath].transform.position);
        if (animator != null)
        {
            
        }
        if (Health <= 0) 
        {
           if (animator != null)
           {
                animator.SetBool(isDyingHash, true);
                gold++;
                Gold.SetText("Gold: "+ gold);
                Destroy(gameObject);
            }
        }
        

        if (Health <= 0)
        {
            if (animator != null)
            {

            }

        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        Health--;
    }
}
