using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Weapon1 weapon1;
    bool onceAtk = true;
    float atkSpeed = 1;
    private AudioManager audioManager;



	private void Start()
	{
		audioManager = GetComponent<AudioManager>();
	}

	void Update()
    {
        atkSpeed = GetComponentInParent<PlayerController1>().atkSpeed;
        if (onceAtk == true)
        {
           
            if (Input.GetMouseButtonDown(0))
            {
                audioManager.PlayAudioClip("attack");
                StartCoroutine(DelayAtk(atkSpeed));
				onceAtk = false;
            }       
           
        }
    }
    private IEnumerator DelayAtk(float atkSpeed)
    {
		weapon1.Attack();   
        yield return new WaitForSeconds(atkSpeed); // Độ trễ 1 giây    
        onceAtk = true;
        
    }  
}
