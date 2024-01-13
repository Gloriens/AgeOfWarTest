using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallComputer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        transform.Rotate(0,180,0);
        Destroy(this.gameObject, 2.0f);
    }
    void Update()
    {
        transform.Translate(Vector3.right * 3 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage hit = other.gameObject.GetComponent<Damage>();
        Debug.Log(hit);
        if(other.tag == "Player")
        {
            if(hit != null)
            {
                Debug.Log("Fire hit!");
                hit.takeDamage(5);
                Destroy(this.gameObject);
            }
        }
    }
}
