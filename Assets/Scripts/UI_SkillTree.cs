using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillTree : MonoBehaviour
{
	private PlayerSkills playerSkills;
	private void Awake()
	{
		playerSkills = new PlayerSkills();
	}
	public void UnlockSkill()
	{
		Debug.Log("Unlocked");
		playerSkills.UnlockSkill(PlayerSkills.SkillType.skill1);
	}
}
