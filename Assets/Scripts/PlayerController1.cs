using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.InputSystem;


public class PlayerController1 : MonoBehaviour
{
  

    [SerializeField] private float moveSpeed = 5f;

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
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed );
    }
    private void Flip()
    {
        bool havemove = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (havemove)
        {
<<<<<<< HEAD
           mySpriteRender.transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f); // sign lay dau cua so ( velocity) bo vao scale 
        }      
    }
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dashTime2 < -1)
        {
            moveSpeed += dashBoots;
            dashTime2 = dashTime1;
            onceDash = true;
        }
        if (onceDash && dashTime2 <= 0)
        {
            moveSpeed -= dashBoots;
            onceDash = false;
        }
        else
        {
            dashTime2 -= Time.deltaTime;
=======
            mySpriteRender.flipX = true;
        
        }
        else
        {
            mySpriteRender.flipX = false;

         
>>>>>>> a2c604f72b442668bf83f73382be5eb7ce98620c
        }
    }
}
