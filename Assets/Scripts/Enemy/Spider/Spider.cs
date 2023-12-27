using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidEffectPrefab;
    private Animator _spiderAnim;
    private Rigidbody2D _rigidSpider;
    public GameObject gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        _rigidSpider = GetComponent<Rigidbody2D>();
        speed = 150.0f;
        _spiderAnim = GetComponentInChildren<Animator>();
    }

    public override void Update()
    {
        EnemyMovement();
        Attack();
    }

    public override void EnemyMovement()
    {
        _rigidSpider.velocity = Vector2.left * Time.deltaTime * speed;

        MoveSpiderAnim(speed);
    }

    public void MoveSpiderAnim(float move)
    {
        _spiderAnim.SetFloat("Move", Mathf.Abs(move));
    }

    public int Health { get; set; }

    public void Damage(int damage)
    {
        Debug.Log("Damage");
        Health = Health - damage;

        if (Health < 1)
        {
            
            _spiderAnim.SetTrigger("Death");
            StartCoroutine(WaitForDeathAnimation(this.gameObject));
            GameObject.Find("GameManager").GetComponent<BankPlayer>().money = GameObject.Find("GameManager").GetComponent<BankPlayer>().money + 31;
        }

    }

    public override void Attack()
    {
        range = 5f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, layer);
        if (hit.collider != null)
        {
            _spiderAnim.SetTrigger("Attack");
            MoveSpiderAnim(0);
            speed = 0;
        }
        else
        {
            speed = 70.0f;
        }

    }

    public void ThrowAcid()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
