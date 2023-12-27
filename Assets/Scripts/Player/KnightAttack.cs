using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    private bool _canDamage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit" + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();
        
        if(hit != null)
        {
            if(_canDamage == true)
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
