using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;

public class DameSource : MonoBehaviour
{
    private GameObject enemy;
    private GameObject player;
    int damage ;

    private void Awake()
    {
        player = GameObject.Find("Player");
        
        enemy = GameObject.FindWithTag("Enemy");
        if (enemy == null)
        {
            Debug.LogError("Không tìm thấy đối tượng Enemy!");
        }
       
       
    }
    private void Start()
    {
        
        damage = player.GetComponent<PlayerController1>().damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.GetComponent<Enemy>()))
        {
            Debug.Log("cham");
            AttackEnemy();
        }
    }
    private void AttackEnemy()
    {
        if (enemy != null)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
       
        

    }
   
}
