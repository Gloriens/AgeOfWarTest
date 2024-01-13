using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SkeletonKnightPlayer : Enemy
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
    
    private float damageCooldown = 1f; // Hasar verme aralığı (saniye)
    private float timeSinceLastDamage = 0f;
    private void Start()
    {
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
    }

    public override void EnemyMovement()
    {       
        _rigidGiant.velocity = Vector2.right * Time.deltaTime * speedMlti * speed;
        
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

    private void OnCollisionStay2D(Collision2D other)
    {
        Damage hit = other.gameObject.GetComponent<Damage>();
        isColliding = true;
        

        if (hit != null && isColliding)
        {
            
            if (hit.CompareTag("Enemy"))
            {
                anim.SetBool("Attack",true);
                speedMlti = 0;
                if (_canDamage == true)
                {
                    Debug.Log("Vurdum");
                    hit.takeDamage(fight.damage);
                    _canDamage = false;
                    StartCoroutine(ReEnableDamage());
                    isColliding = false;
                }
            }else if (hit.CompareTag("Player"))
            {
                speedMlti = 0;
                anim.SetBool("Attack",false);
            }
        }
        else
        {
            speedMlti = 1;
            anim.SetBool("Attack",false);
        }
    }

    private IEnumerator ReEnableDamage()
    {
        // 1 saniye bekle
        yield return new WaitForSeconds(1f);

        // _canDamage'i tekrar true yap
        _canDamage = true;
    }
}
