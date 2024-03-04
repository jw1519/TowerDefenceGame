using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public int health = 100;
   
    // Start is called before the first frame update
    void Start()
    {
        healthText.GetComponent<TextMeshProUGUI>();
        health = 100;
        healthText.SetText($"Health: {health}");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health = health - 1;
            healthText.SetText($"Health: {health}");
        }
        else if (other.gameObject.CompareTag("Knight"))
        {
            health = health - 3;
        }
        else
        {
            health = health - 10;
        }
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Lost!");
            SceneManager.LoadScene("EndGame");
        }
    }
}
