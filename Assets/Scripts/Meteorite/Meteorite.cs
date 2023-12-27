using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour, IDamageable
{
    public float fallspeed = 1.0f;
    public float rollSpeed;
    public int Health { get; set;}

    public void Damage(int damage)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D meteorRigidbody = gameObject.GetComponent<Rigidbody2D>();
        float fallForce = fallspeed; // falling speed of the meteor
        meteorRigidbody.AddForce(Vector2.down * fallForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Meteor Hit");
                hit.Damage(100);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
