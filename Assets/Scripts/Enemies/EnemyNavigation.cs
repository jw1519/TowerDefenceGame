using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Pool;

public class EnemyNavigation : MonoBehaviour
{
    public Vector3 navMeshDestination;
    public NavMeshAgent enemy;
    public Animator animator;
    public Transform endLocation;
    
    public int health = 50;
    int isDyingHash;

    int CannonBallPower = 20;
    int ArrowPower = 10;
    int MagicPower = 25;

    

    private void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        navMeshDestination = enemy.destination;
    }
    // Start is called before the first frame update
    void Start()
    {
        isDyingHash = Animator.StringToHash("IsDying");
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(navMeshDestination, endLocation.position) > 1f)
        {
            navMeshDestination = endLocation.position;
            enemy.destination = navMeshDestination;
        }
        if (health <= 0)
        {
            Gold.instance.IncreaseGold();
            if (animator != null)
            {
                animator.SetBool(isDyingHash, true);
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CannonBall"))
        {
            health = health - CannonBallPower;
        }
        else if (other.gameObject.CompareTag("Arrow"))
        {
            health = health - ArrowPower;
        }
        else if (other.gameObject.CompareTag("Magic"))
        {
            health = health - MagicPower;
        }
        else if (other.gameObject.CompareTag("Destination"))
        {
            gameObject.SetActive(false);
        }
    }
    public IEnumerator DoubleDamageDuration()
    {
        Debug.Log("Double Power");
        CannonBallPower = CannonBallPower * 2;
        MagicPower = MagicPower * 2;
        ArrowPower = ArrowPower * 2;
        yield return new WaitForSeconds(10f);
        Debug.Log("normal power");
        CannonBallPower = CannonBallPower / 2;
        MagicPower = MagicPower / 2;
        ArrowPower = ArrowPower / 2;
    }
}
