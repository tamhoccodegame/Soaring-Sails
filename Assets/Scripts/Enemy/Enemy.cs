using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        Attack,
        Run
    }

    public int health {  get; set; }
    public float speed { get; set; }
    public int damage { get; set; }
    public float attackRadius { get; set; }
    public float nextAttackTimer { get; set; }

    private GameObject player;
    private float tempTime = 0;
    private EnemyState currentState = EnemyState.Run;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.Attack:
                AttackPlayer();
                if (!IsPlayerInRange())
                {
                    SetState(EnemyState.Run);
                }
                break;

            case EnemyState.Run:
                MoveTowardsPlayer();
                break;
        }

        if (IsPlayerInRange())
        {
            SetState(EnemyState.Attack);
        }
    }

    private void MoveTowardsPlayer()
    {
        if (player != null && player.activeSelf)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private bool IsPlayerInRange()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    private void AttackPlayer()
    {
        if (Time.time > tempTime + nextAttackTimer)
        {
            Debug.Log("Danh");
            player.GetComponent<PlayerController1>().TakeDamage(damage);
            tempTime = Time.time;
        }
    }

    public void SetState(EnemyState newState)
    {
        currentState = newState;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("ht" + health);
        health -= damage;  
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
