using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThungRac : Enemy
{
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
    public int numberOfEnemiesToSpawn = 4;
    public float spawnRadius = 2f;
    private bool wasSpawn = false;

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
}
