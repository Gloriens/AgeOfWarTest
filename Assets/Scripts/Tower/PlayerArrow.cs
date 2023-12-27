using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    public Rigidbody2D rg;
    private void Start()
    {
        Destroy(this.gameObject, 3.0f);
    }
    void Update()
    {
        rg.velocity = (Vector2.right * 2);
    }
    private bool _canDamage = true;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            IDamageable hit = other.GetComponent<IDamageable>();

            if (hit != null)
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
