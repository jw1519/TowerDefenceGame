using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Towers : MonoBehaviour
{
    public string enemyTag = "Enemy";
    private Transform target;
    [Header("Sound")]
    public AudioSource ShootSound;

    [Header("Tower Hover Elements")]
    public Material hoverColor;
    public Material OriginalMaterial;
    private Renderer rend;

    public bool ShowRange = true;
    

    //public Transform PartToRotate;
    [Header("Upgradable")]

    public float Range = 100f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public int Damage = 1;

    public Transform firePoint;
    public GameObject ProjectilePrefab;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        rend = GetComponent<Renderer>();
        
    }

    //finding enemy and seeing the distance, targeting system
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // the distance between tower and enemy
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= Range) //if enemy is found within the range
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void Update()
    {
        ///rotation if needed
        //Vector3 direction = target.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(direction); //look rotation
        //Vector3 roation = lookRotation.eulerAngles;
        //PartToRotate.rotation = Quaternion.Euler(0f, roation.y, 0f);

        if (target != null)
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }
        fireCountdown -= Time.deltaTime;
    }
   
    public void Shoot()
    {
        Vector3 distance = (target.transform.position - firePoint.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(distance);

        if (CompareTag("CannonTower"))
        {
            GameObject projectileGO = ProjectileObjectPool.instance.SpawnFromPool("CannonBall", firePoint.position, Quaternion.identity);
            projectiles projectiles = projectileGO.GetComponent<projectiles>();
            
            if (projectiles != null)
            {
                projectiles.Seek(target);
                ShootSound.Play();
            }
        }
        if (CompareTag("ArcherTower"))
        {
            GameObject projectileGO = ProjectileObjectPool.instance.SpawnFromPool("Arrow", firePoint.position, Quaternion.identity);
            projectiles projectiles = projectileGO.GetComponent<projectiles>();
            projectileGO.transform.rotation = rotation;// rotation of projectiles faces the enemies
            projectileGO.transform.localEulerAngles = new Vector3(projectileGO.transform.localEulerAngles.x,
                                                                  projectileGO.transform.localEulerAngles.y,
                                                                  projectileGO.transform.localEulerAngles.z);
            if (projectiles != null)
            {
                projectiles.Seek(target);
                if (ShootSound != null)
                    ShootSound.Play();
            }
        }
        if (this.CompareTag("MagicTower"))
        {
            GameObject projectileGO = ProjectileObjectPool.instance.SpawnFromPool("Magic", firePoint.position, Quaternion.identity);
            projectiles projectiles = projectileGO.GetComponent<projectiles>();
            projectileGO.transform.rotation = rotation; // rotation of projectiles faces the enemies
            projectileGO.transform.localEulerAngles = new Vector3(projectileGO.transform.localEulerAngles.x +90f,
                                                                  projectileGO.transform.localEulerAngles.y,
                                                                  projectileGO.transform.localEulerAngles.z);
            if (projectiles != null)
            {
                projectiles.Seek(target);
                ShootSound.Play();
            }
        }
    }
    //creates a radius that is shown when the tower is selected this is only in editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
