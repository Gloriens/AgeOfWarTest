using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SkeletonKnightEnemy : Enemy
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

    private void OnCollisionStay2D(Collision2D other)
    {
        Damage hit = other.gameObject.GetComponent<Damage>();
        isColliding = true;
        

        if (hit != null && isColliding)
        {
            if (hit.CompareTag("Player"))
            {
                anim.SetBool("Attack",true);
                if (_canDamage == true)
                {
                    Debug.Log("Playera Vurdum");
                    speed = 0;
                    hit.takeDamage(fight.damage);
                    _canDamage = false;
                    StartCoroutine(ReEnableDamage());
                    isColliding = false;
                }
            }
            
        }
        else
        {
            speed = 60;
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
