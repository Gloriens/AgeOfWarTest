using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerEnemy : MonoBehaviour
{
    
    private bool isReadyGiant = true;
    private bool isReadySpider = true;
    private bool isReadySkeleton = true;
    public BankPlayer bankplayer;
    public GameObject MossGiant;
    public GameObject Spider;
    public GameObject Skeleton;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Spawner());
        
    }

    // TO-DO: fix the logic of spawning;
    IEnumerator Spawner()
    {
        StartCoroutine(CounterMossGiant());
        yield return new WaitForSeconds(20f);
        StartCoroutine(CounterSkeleton());
        yield return new WaitForSeconds(20f);
        StartCoroutine(CounterSpider());
        yield return new WaitForSeconds(20f);
    }

    public void SpawnMossGiant()
    {
        isReadyGiant = false;
        Instantiate(MossGiant, spawnPoint.position, Quaternion.identity);

    }

    IEnumerator CounterMossGiant()
    {
        if (isReadyGiant)
        {
            SpawnMossGiant();
            yield return new WaitForSeconds(10);
            isReadyGiant = true;
        }
    }

    public void SpawnSkeleton()
    {
        isReadySkeleton = false;
        Instantiate(Skeleton, spawnPoint.position, Quaternion.identity);

    }

    IEnumerator CounterSkeleton()
    {
        if (isReadySkeleton)
        {
            SpawnSkeleton();
            yield return new WaitForSeconds(10);
            isReadySkeleton = true;
        }
    }

    public void SpawnSpider()
    {
        isReadySpider = false;
        Instantiate(Spider, spawnPoint.position, Quaternion.identity);

    }

    IEnumerator CounterSpider()
    {
        if (isReadySpider)
        {
            SpawnSpider();
            yield return new WaitForSeconds(10);
            isReadySpider = true;
        }
    }
}
