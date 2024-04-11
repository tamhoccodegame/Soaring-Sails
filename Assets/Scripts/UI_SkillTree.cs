using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillTree : MonoBehaviour
{
	
	private void Awake()
	{
		
	}
	public void UnlockSkill()
	{
		Debug.Log("Unlocked");
		PlayerSkills.UnlockSkill(PlayerSkills.SkillType.skill1);
	}
}
