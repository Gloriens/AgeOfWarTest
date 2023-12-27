using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private PlayerAnimation _playerAnim;
    private Rigidbody2D _rigid;
    [SerializeField] private float _speed = 30.0f;
    public float detectionRange = 0.2f;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        Health = 20;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        KnightMovement();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, detectionRange, enemyLayer);
        if(hit.collider != null)
        {
                _playerAnim.Attack();
                _playerAnim.Move(0);
                _speed = 0;           
        }else
        {
            _speed = 30.0f;
        }
    }

    public void KnightMovement()
    {
        _rigid.velocity = Vector2.right * Time.deltaTime * _speed;

        _playerAnim.Move(_speed);
    }

    public int Health { get; set; }

    public void Damage(int damage)
    {
        Debug.Log("Damage Player");
        Health -= damage;

        if (Health < 1)
        {
            _playerAnim.Death();
            Destroy(this.gameObject);
            
        }

    }

}
