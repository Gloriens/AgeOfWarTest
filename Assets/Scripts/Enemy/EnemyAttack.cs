using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    public virtual void init()
    {
        
    }

    private bool _canDamage = true;
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit" + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (_canDamage == true)
            {
                hit.Damage(1);
                _canDamage = false;
                StartCoroutine(ReDamage());
            }
        }
    }

    IEnumerator ReDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
