using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MeteorShowerButton : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject AsterBig3;


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
        int numberOfMeteors = 50; // number of meteors that will fall

        for (int i = 0; i < numberOfMeteors; i++)
        {
            // spawn area of the meteors
            float spawnX = Random.Range(-5f, 5f);
            float spawnY = Random.Range(-2f, 50f);

            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

            GameObject meteor = Instantiate(AsterBig3, spawnPosition, Quaternion.identity);

            Rigidbody2D meteorRigidbody = meteor.GetComponent<Rigidbody2D>();
            float fallForce = 5f; // falling speed of the meteor
            meteorRigidbody.AddForce(Vector2.down * fallForce, ForceMode2D.Impulse);

            Meteor meteorScript = meteor.AddComponent<Meteor>();
        }

        // We can also trigger a visual effect or play a sound for the meteor shower
        // Play a sound effect, particle effect and etc
        // For example: meteorShowerEffect.Play();
    }

}
