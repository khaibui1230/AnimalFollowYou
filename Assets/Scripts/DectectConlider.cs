using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class DectectConlider : MonoBehaviour
{
    private SpawnManager spawnManager;

    private int pointLives = 0;
    public int maxLives = 3;


    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        pointLives = maxLives;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player"))
        {
            if (pointLives <= 0)
            {
                spawnManager.GameOver();
                Destroy(gameObject);
                Destroy(other.gameObject);

            }
            else
            {
                pointLives--;
                Destroy(other.gameObject);
                spawnManager.UpdateLivesText(pointLives);
            }
        }

        else if (other.CompareTag("Enemies"))
        {
            other.GetComponent<AnimalHunger>().AddDamage(1);
        }
        else if (other.CompareTag("Shoot"))
        {
            
            Destroy(other.gameObject);
        }
    }
}
