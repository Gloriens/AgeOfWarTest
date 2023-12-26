using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BankPlayer : MonoBehaviour
{
    public int money = 31;
    public TextMeshProUGUI coin_count;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coin_count.text = money.ToString();
    }
}