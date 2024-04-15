using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public Weapon1 weapon1;
    public bool atkStop = true;
    bool onceCall = true;
    private void Update()
    {
       
        if (atkStop == false && onceCall == true)
        {          
                StartCoroutine(DelayAtk());
            onceCall = false;
        }
    }
    private IEnumerator DelayAtk()
    {    
        if (onceCall)
        {
            weapon1.Attack();
        }
        yield return new WaitForSeconds(1f); // Độ trễ 1 giây    
        onceCall = true;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng trong vùng tấn công là quái vật
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            if (weapon1 != null)
            {                       
                atkStop = false;             
            }
        }
    }
      void OnTriggerExit2D(Collider2D other)
        {
            
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
            Debug.Log("tr");
                atkStop = true;
            }
        }
}
