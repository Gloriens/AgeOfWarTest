using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected LayerMask layer;
    [SerializeField] protected float range;

    public virtual void Attack()
    {

    }


    public abstract void Update();

    public abstract void EnemyMovement();

    public virtual IEnumerator WaitForDeathAnimation(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
     
}
