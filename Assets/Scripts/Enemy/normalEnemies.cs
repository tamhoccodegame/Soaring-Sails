using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalEnemies : Enemy
{
    public int health;
    [SerializeField] private float speed;
    [SerializeField] private int damageMin;
    [SerializeField] private int damageMax;
    [SerializeField] private float attackRadius;
    [SerializeField] private float nextAttackTimer;
    public int exp;
    //public ParticleSystem deadEffectChild;

    private void Start()
    {
        base.health = health;
        base.speed = speed;
        base.damageMin = damageMin;
        base.damageMax = damageMax;
        base.attackRadius = attackRadius;
        base.nextAttackTimer = nextAttackTimer;
        base.exp = exp;
        //base.deadEffect = deadEffect;
    }
}
