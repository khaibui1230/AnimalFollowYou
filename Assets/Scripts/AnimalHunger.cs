using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{

    // for the variable
    public float fullHealth;
    public float currentHealth;
    public bool enemiDied = false;
    // for the local component

    // for the global component
    public Canvas enemyCanvas;
    public Slider enemySlider;

    // for the global script
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    // awake will call in the first activity by player
    void Awake() 
    {    
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        currentHealth = fullHealth;
        enemySlider.minValue = 0;
        enemySlider.maxValue = fullHealth;
        enemySlider.value = 0;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public void AddDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        enemySlider.fillRect.gameObject.SetActive(true);
        enemySlider.value = currentHealth;
        if(currentHealth == 0)
        {
            enemiDied = true;
            spawnManager.UpDateScore();
            Destroy(gameObject, 0.1f);
        }
    }
    //public void FeedAnimal(int amount)
    //{
    //    currenFedAmount += amount;
    //    hungerSlider.fillRect.gameObject.SetActive(true);
    //    hungerSlider.value = currenFedAmount;

    //    if(currenFedAmount >= amountToBeFed)
    //    {
    //        spawnManager.UpDateScore();
    //        Destroy(gameObject, 0.1f);
    //    }
    //}
}
