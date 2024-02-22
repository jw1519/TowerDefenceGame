using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    private int health = 100;
   

    // Start is called before the first frame update
    void Start()
    {
        healthText.GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health = health - 1;
            healthText.SetText("Health: " +  health);
        }
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Lost!");
            SceneManager.LoadScene("EndGame");
        }
    }
}
