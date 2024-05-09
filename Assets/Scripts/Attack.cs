using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	public Weapon1 weapon1;
	bool onceAtk = false;
	[SerializeField] float atkSpeed;
	public float atkSpeed2;





	void Update()
	{
		atkSpeed = transform.parent.GetComponentInParent<PlayerController1>().atkSpeed;
		if (onceAtk == true)

			if (Input.GetMouseButtonDown(0) && atkSpeed2 < atkSpeed)
			{

				if (onceAtk == true)
				{
					atkSpeed2 = atkSpeed;
				}
				if (onceAtk == true)
				{
					weapon1.Attack();
					onceAtk = false;
				}
			}
		if (atkSpeed2 <= 0 && onceAtk == false)
		{
			onceAtk = true;
		}
		else
		{
			atkSpeed2 -= Time.deltaTime;
		}

	}

}
/* if (onceAtk == true)
	{         
		if (Input.GetMouseButtonDown(0))
		{         
			StartCoroutine(DelayAtk(atkSpeed));
			onceAtk = false;
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
{

weapon1.Attack();
yield return new WaitForSeconds(atkSpeed); // Độ trễ 1 giây    
onceAtk = true;
}  */
