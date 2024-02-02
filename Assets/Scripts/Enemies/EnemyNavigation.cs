using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;

public class EnemyNavigation : MonoBehaviour
{
    Vector3 destination;
    public NavMeshAgent Enemy;
    public Animator animator;
    public Transform target;

    public TextMeshProUGUI Gold;
    public TextMeshProUGUI healthText;

    private int gold = 0;
    public int Health = 100;
    int isDyingHash;

    int CannonBallPower = 10;
    int ArrowPower = 5;
    int MagicPower = 15;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Gold.GetComponent<TextMeshProUGUI>();
        healthText.GetComponent<TextMeshProUGUI>();
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
        //bool IsDying = animator.GetBool(isDyingHash);

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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CannonBall"))
        {
            Health = Health - CannonBallPower;
        }
        else if (other.gameObject.CompareTag("Arrow"))
        {
            Health = Health - ArrowPower;
        }
        else if (other.gameObject.CompareTag("Magic"))
        {
            Health = Health - MagicPower;
        }
    }
}
