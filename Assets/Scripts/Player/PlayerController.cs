using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    // configuration parameters
    [Header("Player Stats")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float health, maxHealth = 100f;

    [Header("Player Audio")]
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;
    [SerializeField] AudioClip reloadSound;
    [SerializeField] [Range(0, 1)] float reloadSoundVolume = 0.25f;

    [Header("Player Parts")]
    public Rigidbody2D rb;
    public Weapon weapon;
    public Camera sceneCamera;


    private Vector2 moveDirection;
    private Vector2 mousePosition;

    public static event Action<PlayerController> OnPlayerKilled;
    


    Transform target;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            weapon.Fire();
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload();
            AudioSource.PlayClipAtPoint(reloadSound, Camera.main.transform.position, reloadSoundVolume);

        }


        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

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
        Debug.Log($"Damage amount: {damageAmount}");
        health -= damageAmount;
        Debug.Log($"Health is now: {health}");

        if (health <= 0)
        {
            Destroy(gameObject, Time.timeScale = 0f);
            OnPlayerKilled?.Invoke(this);

        }
    }

    
}
