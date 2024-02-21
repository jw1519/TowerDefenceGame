using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class projectiles : MonoBehaviour
{

    public Transform target;
    public float speed = 10f;
    public void Seek(Transform target)
    {
        this.target = target;
    }
 

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            
            gameObject.SetActive(false);
            return;
        }

        Vector3 direction = target.position - transform.position;  
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);

    }
    //unactivates when hit enemy
    private void HitTarget()
    {
        gameObject.SetActive(false);

    }
     

}
