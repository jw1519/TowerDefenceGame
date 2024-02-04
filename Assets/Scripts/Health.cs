using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public int health = 100;
    public Transform target;
   

    // Start is called before the first frame update
    void Start()
    {
        healthText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destimation"))
        {
            health = health - 1;
            healthText.SetText("Health: " +  health);
        }
    }
}
