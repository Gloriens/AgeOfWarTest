using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MeteorShowerButton : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject meteor;
    public float fallspeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerMeteorShower()
    {
        int requiredGold = 100;

        // Check if the player has enough gold
        if (gameManager.GetComponent<BankPlayer>().money >= requiredGold)
        {
            StartMeteorShower();
            gameManager.GetComponent<BankPlayer>().money -= requiredGold;
        }
        else
        {
            Debug.Log("Not Enough Gold");
        }
    }

    void StartMeteorShower()
    {
        int numberOfMeteors = 100; // number of meteors that will fall

        for (int i = 0; i < numberOfMeteors; i++)
        {
            // spawn area of the meteors
            float spawnX = Random.Range(-10f, 10f);
            float spawnY = Random.Range(10f, 100f);

            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

            Instantiate(meteor, spawnPosition, Quaternion.identity);

        }

        // We can also trigger a visual effect or play a sound for the meteor shower
        // Play a sound effect, particle effect and etc
        // For example: meteorShowerEffect.Play();
    }

}
