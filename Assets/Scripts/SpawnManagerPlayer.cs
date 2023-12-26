using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class SpawnManagerPlayer : MonoBehaviour
{
    public GameObject knight;
    public Transform spawnPoint;
    [SerializeField] public float coolDownKnight;

    private bool spawnCoolingDown = false;

    public TextMeshProUGUI countdownText;

    private float countdown;

    public GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    private void Update()
    {
        countdownText.text = countdown.ToString();
    }

    public void SpawnKnight()
    {
        if ((gameManager.GetComponent<BankPlayer>().money - 30) < 0)
        {
            Debug.Log("Not Enough Gold");
        }
        else
        {
            if (!spawnCoolingDown)
            {
                gameManager.GetComponent<BankPlayer>().money = gameManager.GetComponent<BankPlayer>().money - 30;
                Instantiate(knight, spawnPoint.position, Quaternion.identity);
                StartCoroutine(CooldownCoroutine());
            }
        }
       
    }

    IEnumerator CooldownCoroutine()
    {
        spawnCoolingDown = true;

        countdown = coolDownKnight;
        while (countdown > 0)
        {
            yield return new WaitForSeconds(1f);
            countdown -= 1f;
        }

        spawnCoolingDown = false;
    }
}