using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowProduct : MonoBehaviour, IProduct
{
    [SerializeField] private string productName = "Arrow";

    public string ProductName { get => productName; set => productName = value; }

    private AudioSource audioSource;

    public void Initialize()
    {
        // do some logic here
        audioSource = GetComponent<AudioSource>();
        audioSource?.Stop();
        audioSource?.Play();

    }
}
