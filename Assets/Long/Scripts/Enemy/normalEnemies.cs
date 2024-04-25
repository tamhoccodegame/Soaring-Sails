using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalEnemies : Enemy
{
    [SerializeField] private new int health;
    [SerializeField] private new float speed;
    [SerializeField] private new int damage;
    [SerializeField] private new float attackRadius;
    [SerializeField] private new float nextAttackTimer;

    private void Start()
    {
        base.health = health;
        base.speed = speed;
        base.damage = damage;
        base.attackRadius = attackRadius;
        base.nextAttackTimer = nextAttackTimer;
    }
}
