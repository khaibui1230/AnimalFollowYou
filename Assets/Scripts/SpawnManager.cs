using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textLive;
    public Button restartButton;
    public Button startButton;

    private float spawnRangeX = 20;

    private float spawnRangeZ = 14;
    private float spawnPosZ = 30;
    private float spawnInterval = 3f;
    private float startDelay;
    public int score = 0;


    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0f;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);

        InvokeRepeating();
        UpDateScore();

    }

    private void InvokeRepeating()
    {
        startDelay = Random.Range(1, 2);
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRightAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnBehindPlayer", startDelay, spawnInterval);
    }


    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }
    public void StarGame()
    {
        Time.timeScale = 1f;
        startButton.gameObject.SetActive(false);
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            startButton.gameObject.SetActive(true);
        }
    }



    // game over
    public void GameOver()
    {

        Time.timeScale = 0f;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }
    // cap nhat deim de hien thi cho nguoi choi
    public void UpDateScore()
    {

        score = score + 5;
        textScore.text = "Point : " + score;
    }
    // cap nhat diem ton ta cua nguoi nguoi
    public void UpdateLivesText(int pointLives)
    {
        textLive.text = "Lives :" + pointLives;
    }
    // spawn vi tri cua nguoi choi                                                                                         
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
    // spawn theo chieu ngang
    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-spawnRangeX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        Vector3 rotation = new Vector3(0, 90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }
    void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnRangeX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        Vector3 rotation = new Vector3(0, -90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }
    void SpawnBehindPlayer()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, -spawnRangeZ);
        Vector3 rotation = new Vector3(0, 0, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }
}
