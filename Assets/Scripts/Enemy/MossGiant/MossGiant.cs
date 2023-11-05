using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    private Animator _mossGiantAnim;
    private Rigidbody2D _rigidGiant;
    private void Start()
    {
        _rigidGiant = GetComponent<Rigidbody2D>();
        speed = 60.0f;
        _mossGiantAnim = GetComponentInChildren<Animator>();
       // Health = base.health;
    }

    public override void Update()
    {
        EnemyMovement();
        Attack();
    }

     public override void EnemyMovement()
    {       
        _rigidGiant.velocity = Vector2.left * Time.deltaTime * speed;

        MoveGiantAnim(speed);
    }

    public void MoveGiantAnim(float move)
    {
        _mossGiantAnim.SetFloat("Move", Mathf.Abs(move));
    }

    // attack animation and attack method will be made.

    public int Health { get; set; }

    public void Damage()
    {
        Debug.Log("Damage");
        Health--;

        if(Health < 1)
        {
            _mossGiantAnim.SetTrigger("Death");
            StartCoroutine(WaitForDeathAnimation(this.gameObject));
        }

    }

    public override void Attack()
    {
        range = 1f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, layer);
        if (hit.collider != null)
        {
            _mossGiantAnim.SetTrigger("Attack");
            MoveGiantAnim(0);
            speed = 0;
        }
        else
        {
            speed = 70.0f;
        }

    }
}
