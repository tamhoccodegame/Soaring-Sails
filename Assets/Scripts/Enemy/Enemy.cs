using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        attack,
        run,
        specialSkill
    }

    public int health { get; set; }
    public float speed { get; set; }
    public int damageMin { get; set; }
    public int damageMax { get; set; }
    public float attackRadius { get; set; }
    public float nextAttackTimer { get; set; }
    public int exp {  get; set; }
    protected float delayDie;
    AudioManager audioManager;
    protected GameObject player;
    private float tempTime = 0;
    [SerializeField] protected EnemyState currentState = EnemyState.run;
    protected Animator anim;
    private float scale;
    protected ParticleSystem deadEffect;

    private void Awake()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        scale = transform.localScale.x;
        audioManager = GetComponent<AudioManager>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.attack:
                AttackPlayer();
                break;

            case EnemyState.run:
                Move();
                break;

            case EnemyState.specialSkill:
                SpecialSkill();
                break;
        }

        ControllerAction();
    }

    public virtual void ControllerAction()
    {
        if (IsPlayerInRange())
        {
            SetState(EnemyState.attack);
        }
        else if (!IsPlayerInRange())
        {
            SetState(EnemyState.run);
        }
    }

    private void Move()
    {
        FlipTowardsPlayer();
        anim.SetTrigger("Run");
        if (player != null && player.activeSelf)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public bool IsPlayerInRange()
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
        anim.SetTrigger("Attack");
        if (Time.time > tempTime + nextAttackTimer)
        {
            Debug.Log("Attack");
            player.GetComponent<PlayerController1>().TakeDamage(RandomDamage(damageMin, damageMax));
            tempTime = Time.time;
        }
    }

    public void SetState(EnemyState newState)
    {
        currentState = newState;
    }

    private int RandomDamage(int min, int max)
    {
        return Random.Range(min, max + 1);
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
            Debug.Log(health);
        }
        audioManager.PlayAudioClip("enemyHitImpact"); 
    }

    public virtual void Die()
    {
        deadEffect.Play();
        player.transform.Find("Character").GetComponent<Player>().AddExperienceFromEnemy(exp);
        ItemWorld.DropItem(transform.position, new Item { itemType = Item.ItemType.Coin, amount = Random.Range(20, 15) });
        ItemWorld.DropItem(transform.position, new Item { itemType = Item.ItemType.Stick, amount = 1 });
		StartCoroutine(BeforeDie());
	}

    IEnumerator BeforeDie()
    {
		yield return new WaitForSeconds(delayDie);
		Destroy(gameObject);
	}
    private void FlipTowardsPlayer()
    {
        if (player != null && player.activeSelf)
        {
            if (transform.position.x < player.transform.position.x)
            {
                transform.localScale = new Vector3(scale, scale, 1);
            }
            else
            {
                transform.localScale = new Vector3(-scale, scale, 1);
            }
        }
    }

    public virtual void SpecialSkill()
    {
        anim.SetTrigger("Skill");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

}

