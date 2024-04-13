using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
public class UI_SkillTree : MonoBehaviour
{
	private PlayerSkills playerSkills;
	private void Awake()
	{
		transform.Find("Skill_1").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.UnlockSkill(PlayerSkills.SkillType.HealthMax_1);
			//Debug.Log("Unlock " + PlayerSkills.SkillType.skill1.ToString());
		};
		transform.Find("Skill_2").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.UnlockSkill(PlayerSkills.SkillType.MovementSpeed_1);	
			//Debug.Log("Unlock " + PlayerSkills.SkillType.skill2.ToString());
		};
		transform.Find("Skill_3").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.UnlockSkill(PlayerSkills.SkillType.Damage_1);
			//Debug.Log("Unlock " + PlayerSkills.SkillType.skill3.ToString());
		};
	}
	
	public void SetPlayerSkills(PlayerSkills playerSkills)
	{
		this.playerSkills = playerSkills;
	}

}
