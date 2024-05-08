using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;

public class DameSource : MonoBehaviour
{
    
    private GameObject player;
    int damage ;
    public ParticleSystem hitImpact;

    private void Awake()
    {
        player = GameObject.Find("Player");
       
    }
    private void Start()
    {
        damage = player.GetComponent<PlayerController1>().damage;
    }

	
	private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            Instantiate(hitImpact, enemy.transform.position, Quaternion.identity);
            enemy.TakeDamage(damage);
        }
    }

    
}
 
   
