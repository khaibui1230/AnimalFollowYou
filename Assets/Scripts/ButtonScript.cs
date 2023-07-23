using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private SpawnManager spawnManager;
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    public void RestartSence()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartSence()
    {
        

        spawnManager.StarGame();
    }
}
