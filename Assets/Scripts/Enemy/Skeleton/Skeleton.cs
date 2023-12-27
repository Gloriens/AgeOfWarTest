using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    private Animator _skeletonAnim;
    private Rigidbody2D _rigidSkeleton;
    public GameObject gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        _rigidSkeleton = GetComponent<Rigidbody2D>();
        speed = 70.0f;
        _skeletonAnim = GetComponentInChildren<Animator>();

        Health = base.health;
    }

    public override void Update()
    {
        EnemyMovement();
        Attack();

    }

    public override void EnemyMovement()
    {
       
       _rigidSkeleton.velocity = Vector2.left * Time.deltaTime * speed;       

        MoveSpiderAnim(speed);
    }

    public void MoveSpiderAnim(float move)
    {
        _skeletonAnim.SetFloat("Move", Mathf.Abs(move));
    }

    public int Health { get; set; }

    public void Damage(int damage)
    {
        Debug.Log("Damage");
        Health = Health - damage;

        if (Health < 1)
        {
           GameObject.Find("GameManager").GetComponent<BankPlayer>().money = GameObject.Find("GameManager").GetComponent<BankPlayer>().money + 25;
            _skeletonAnim.SetTrigger("Death");
            StartCoroutine(WaitForDeathAnimation(this.gameObject));
        }

    }

    public override void Attack()
    {
        range = 1f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, layer);
        if (hit.collider != null)
        {
            _skeletonAnim.SetTrigger("Attack");
            MoveSpiderAnim(0);
            speed = 0;
        }
        else
        {
            speed = 70.0f;
        }
        
    }

}
