using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnim : MonoBehaviour
{
    GameObject weapon;
    private void Start()
    {
        weapon = GameObject.Find("Player");
        if (weapon == null)
        {
            Debug.LogError("deo thay");
        }
    }
    void Satk()
    {
        weapon.GetComponentInChildren<Weapon1>().Satk();
    }
    void Eatk()
    {
        weapon.GetComponentInChildren<Weapon1>().Eatk();
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
