using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    public float healthTest;
    public float damage;

    public void takeDamage(float damage)
    {
        healthTest = healthTest - damage;
    }
}
