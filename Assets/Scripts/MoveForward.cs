using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    public float Speed = 40f;

    private SpawnManager spanwManager;
    private float topBound = 12f;
    private float botBound = -30f;
    public int pointForPlayer = 5;




    // Start is called before the first frame update
    void Start()
    {
        //tham chieu den ham SpawnManager
        spanwManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemies();


        if (transform.position.z > topBound || transform.position.z < botBound)
        {
            Destroy(gameObject);

        }




    }

    private void MoveEnemies()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    Destroy(gameObject);
    //    spanwManager.UpDateScore();

    //}

}
