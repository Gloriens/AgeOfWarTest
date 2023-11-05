using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerPlayer : MonoBehaviour
{
    public GameObject knight;
    public Transform spawnPoint;

    
    public void Start()
    {
        
    }
    public void Update()
    {
        
    }
    public void SpawnKnight()
    {
        Instantiate(knight, spawnPoint.position, Quaternion.identity);
    }
}
