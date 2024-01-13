using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPlayer : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 2.0f);
    }
    void Update()
    {
        transform.Translate(Vector3.right * 3 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage hit = other.gameObject.GetComponent<Damage>();
        if(other.tag == "Enemy")
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
