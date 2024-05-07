using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.InputSystem;
using System;
using CodeMonkey;
using UnityEngine.XR;
public class PlayerController1 : MonoBehaviour
{
    
    public event EventHandler OnPlayerDie;

    public int health;
    public int damage = 10;
    public float atkSpeed;

	Animator animator;

    public float moveSpeed = 5f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    public SpriteRenderer mySpriteRender;

    // Skill dash //
    [SerializeField] float dashBoots = 15f;
    [SerializeField] float dashTime1 = 0.25f;
    public float dashTime2;
    bool onceDash = false;
  

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();

	}

	private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        Dash();
        Panimation();
    }

    private void FixedUpdate()
    {
        Move();
        Flip();

    }

    private void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    private void Move()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
    private void Flip()
    {
        bool havemove = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (havemove)
        {        
            mySpriteRender.transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f); // sign lay dau cua so ( velocity) bo vao scale 
        }
    }
    void Panimation()
    {
        if (movement.x != 0 || movement.y != 0)
        {

            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dashTime2 < -1)
        {
            animator.SetBool("Dash", true);
            moveSpeed += dashBoots;
            dashTime2 = dashTime1;
            onceDash = true;
        }
        if (onceDash && dashTime2 <= 0)
        {
            animator.SetBool("Dash", false);
            moveSpeed -= dashBoots;
            onceDash = false;
        }

        else
        {
            dashTime2 -= Time.deltaTime;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Time.timeScale = 0;
        OnPlayerDie?.Invoke(this, EventArgs.Empty);
    }
    
    // HelloWorld
}

