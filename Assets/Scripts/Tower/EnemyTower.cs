using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTower : MonoBehaviour, IDamageable
{
    public LayerMask layer;
    public float range;
    public GameObject arrowPrefab;
    public float maxHealth = 50f;
    public Image healthBar;
    private float _coolDown = 2.0f;
    private float _timer;
    public Transform spawnTransform;
    public int Health { get; set; }

    public void Damage(int damage)
    {
        Debug.Log("Hit castle");
        Health -= damage;
        healthBar.fillAmount = Health / maxHealth;
        if (Health < 1)
        {
            Destroy(this.gameObject);
            GameObject.Find("GameManager").GetComponent<GameOver>().GameOverUI();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Health = (int)maxHealth;
        _timer = _coolDown;
    }

    public void Attack()
    {
        range = 10f;
        RaycastHit2D hit = Physics2D.Raycast(spawnTransform.position, Vector2.left, range, layer);
        if (hit.collider != null)
        {
            _timer -= Time.deltaTime;
            if(_timer <= 0)
            {
                Instantiate(arrowPrefab, spawnTransform.position, Quaternion.identity);
                _timer = _coolDown;
            }
            
        }
        else
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
}
