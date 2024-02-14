using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;

public class EnemyNavigation : MonoBehaviour
{
    public static EnemyNavigation instance;

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("more than one gamemanager");

        instance = this;
    }




    Vector3 destination;
    public NavMeshAgent Enemy;
    public Animator animator;
    public Transform target;

    public TextMeshProUGUI Gold;
    
    private int gold = 0;
    public int health = 100;
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
        IncreaseGold();

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
            //Destroy(gameObject);
        }
    }
    public void IncreaseGold()
    {
        if (health <= 0)
        {
            gold++;
            Gold.SetText("Gold: " + gold);

            if (animator != null)
            {
                animator.SetBool(isDyingHash, true);
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }
        }
    }
}
