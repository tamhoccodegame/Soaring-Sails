using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossThungRac : Enemy
{
    public event EventHandler OnBossDie;
    public event EventHandler<OnBossDamagedEventArgs> OnBossDamaged;
    public class OnBossDamagedEventArgs : EventArgs
    {
        public int health;
    }

    public int health;
    [SerializeField] private float speed;
    [SerializeField] private int damageMin;
    [SerializeField] private int damageMax;
    [SerializeField] private float attackRadius;
    [SerializeField] private float nextAttackTimer;
    [SerializeField] private float nextChangeAction;
    public int exp;
    private float timer;
    public GameObject enemyPrefab;
    public ParticleSystem deadEffect;
    public int numberOfEnemiesToSpawn = 4;
    public float spawnRadius = 2f;
    private bool wasSpawn = false;
    private AudioManager audioManager;

	private void Start()
    {
        timer = nextAttackTimer;
        base.health = health;
        base.speed = speed;
        base.damageMin = damageMin;
        base.damageMax = damageMax;
        base.attackRadius = attackRadius;
        base.nextAttackTimer = nextAttackTimer;
        base.exp = exp;
        base.deadEffect = deadEffect;
        base.delayDie = .5f;
    }

    public override void ControllerAction()
    {
        Debug.Log(currentState);
        if (IsPlayerInRange())
        {
            SetState(EnemyState.attack);
            timer = Time.time + nextChangeAction;
        }
        else if (!IsPlayerInRange())
        {
            if(Time.time > timer)
            {
                SetState(EnemyState.specialSkill);
                timer = Time.time + nextChangeAction;
            }else if(currentState != EnemyState.specialSkill)
            {
                SetState(EnemyState.run);
            }
        }
    }

    public void SetStateRun()
    {
        anim.SetTrigger("Run");
        wasSpawn = false;
        SetState(EnemyState.run);
    }

    public override void SpecialSkill()
    {
        base.SpecialSkill();
        if (!wasSpawn)
        {
            wasSpawn = true;
            for (int i = 0; i < numberOfEnemiesToSpawn; i++)
            {
                float angle = i * Mathf.PI * 2 / numberOfEnemiesToSpawn;
                Vector3 spawnPosition = transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * spawnRadius;
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

	public override void TakeDamage(int damage)
	{
		base.TakeDamage(damage);
        OnBossDamaged?.Invoke(this, new OnBossDamagedEventArgs { health = base.health});
	}

    public override void Die()
    {
        base.Die();
        OnBossDie?.Invoke(this, EventArgs.Empty);
	}
}
