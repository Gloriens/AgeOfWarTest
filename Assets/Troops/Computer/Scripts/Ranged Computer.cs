using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RangedComputer : Enemy
{
    // Start is called before the first frame update
     private Animator anim;
    private Rigidbody2D _rigidGiant;
    public GameObject gameManager;
    private bool _canDamage = true;
    [FormerlySerializedAs("HealthBar")] public Damage fight;
    private float myHealth;
    private bool isAlive;
    private bool isColliding;
    public float speedMlti;
    [FormerlySerializedAs("Range")] public float Rangexd;
    public GameObject Bulletpoint;
    public GameObject Bullet;
    
    private float damageCooldown = 1f; // Hasar verme aralığı (saniye)
    private float timeSinceLastDamage = 0f;
    public LayerMask whatisEnemy;
    private void Start()
    {
        transform.Rotate(0,180,0);
        isAlive = true;
        myHealth = fight.healthTest;
        Debug.Log(myHealth);
        Debug.Log(fight.healthTest);
        gameManager = GameObject.Find("GameManager");
        _rigidGiant = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager GameObject not found.");
        }
    }

    public override void Update()
    {
        EnemyMovement();
        amIdead();
        AttackAnim();
        
    }

    public override void EnemyMovement()
    {       
        _rigidGiant.velocity = Vector2.left * Time.deltaTime * speed *speedMlti;
        
    }

    private void FixedUpdate()
    {
        
    }

    // attack animation and attack method will be made.
    
    

    public void amIdead()
    {
        if(fight.healthTest < 1 && isAlive)
        {
            isAlive = false;
            anim.SetBool("Dead",true);
            StartCoroutine(WaitForDeathAnimation(this.gameObject));
            GameObject.Find("GameManager").GetComponent<BankPlayer>().money = GameObject.Find("GameManager").GetComponent<BankPlayer>().money + 15;
        }
    }

    void AttackAnim()
    {
        RaycastHit2D hit;
        Vector2 raycastOrigin = new Vector2(transform.position.x - 2f, transform.position.y);

        hit = Physics2D.Raycast(raycastOrigin, Vector2.left, 0.1f);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                speed = 0;
                anim.SetBool("Attack", true);
                if (_canDamage)
                {
                    _canDamage = false;
                    StartCoroutine(ReEnableDamage());
                }
               
            }
            else
            {
                // Başka bir şey vuruldu
                anim.SetBool("Attack", false);
                speed = 60;
            }
        }
        else
        {
            Debug.Log("vurmadım");
            anim.SetBool("Attack", false);
            speed = 60;
        }
    }

    private IEnumerator ReEnableDamage()
    {
        Vector2 origin = new Vector2(transform.position.x - 0.2f, transform.position.y);
        yield return new WaitForSeconds(1f);
        Instantiate(Bullet, Bulletpoint.transform.position, Quaternion.identity);
        _canDamage = true;
        
    }
    
    void OnDrawGizmos()
    {
        // Ray'ı çiz
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.right * Rangexd));
    }

    
}
