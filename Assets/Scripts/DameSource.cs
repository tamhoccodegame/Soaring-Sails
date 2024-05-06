using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;

public class DameSource : MonoBehaviour
{
    
    private GameObject player;
    int damage ;

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
        TraceDamage(damage);
    }

    private void TraceDamage(int damage)
    {
		List<Collider2D> hitEnemies = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();

        filter.SetLayerMask(LayerMask.GetMask("Enemy"));
        filter.useLayerMask = true;

		int numCollider = Physics2D.OverlapCollider(GetComponent<Collider2D>(), filter , hitEnemies);

        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy != null)
            { 
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
            
        }
	}
}
 
   
