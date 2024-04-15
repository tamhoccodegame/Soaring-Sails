﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    // Skill dash //   
    [SerializeField] float dashBoots = 15f; 
    [SerializeField] float dashTime1;      
    public float dashTime2;
    bool onceDash = false; 

    
    [SerializeField] float moveSpeed = 10f;

    Vector3 moveInput;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    void Update()
    {
        Flip();
        Run();
        Dash();
       
    }
    

   
    void Run()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;      
    }

    void Flip()
    {
        if (moveInput.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput.x), 1f, 1f);
        }
    }
    void PAnimation()
    {
        //anim.SetFloat("Running", Mathf.Abs(moveInput.x));
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
        }
    }
}
