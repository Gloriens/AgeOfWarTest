using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    public Rigidbody2D rg;
    private void Start()
    {
        Destroy(this.gameObject, 3.0f);
    }
    void Update()
    {
        rg.velocity = (Vector2.left * 2);
    }
    private bool _canDamage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();

            if(hit != null)
            {
                if (_canDamage == true)
                {
                    Debug.Log("Arrow hit!");
                 hit.Damage(4);
                    _canDamage = false;
                    StartCoroutine(ReDamage());
                    Destroy(gameObject, 0.2f);
                }
            }

        }
    }

    IEnumerator ReDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
