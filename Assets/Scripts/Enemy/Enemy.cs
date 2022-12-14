using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public static event Action<Enemy> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    public Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Player").transform;
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"Dage amount: {damageAmount}");
        health -= damageAmount;
        Debug.Log($"Health is now: {health}");
       
        if(health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }

    private void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = MathF.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController playerComponent))
        {
            
            playerComponent.TakeDamage(1);
            
        }

        ScoreScript.scoreValue += 1;
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);

    }

   
    
}
