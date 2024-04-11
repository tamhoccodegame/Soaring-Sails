using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerSkills playerSkills;
    // Start is called before the first frame update
    void Start()
    {
        playerSkills = new PlayerSkills();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            if(CanUseSkill1())
            {
                Vector3 newLocation = new Vector3(1,1,0);
                transform.localPosition += newLocation;
            }
        }
    }
    

    public bool CanUseSkill1()
    {
        return playerSkills.isSkillUnlocked(PlayerSkills.SkillType.skill1);
    }
}
