using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;
public class UI_SkillTree : MonoBehaviour
{
	[SerializeField] private Material skillLockedMaterial;
	[SerializeField] private Material skillUnlockableMaterial;

	private PlayerSkills playerSkills;
	private TextMeshProUGUI skillPointsText;
	private void Awake()
	{
		skillPointsText = transform.Find("PointText").GetComponent<TextMeshProUGUI>();

		transform.Find("HealthMax_1").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.TryUnlockSkill(PlayerSkills.SkillType.HealthMax_1);
		};

		transform.Find("MovementSpeed_1").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.TryUnlockSkill(PlayerSkills.SkillType.MovementSpeed_1);	
		};

		transform.Find("Damage_1").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Damage_1);
		};

		transform.Find("HealthMax_2").GetComponent<Button_UI>().ClickFunc = () =>
		{
			if (!playerSkills.TryUnlockSkill(PlayerSkills.SkillType.HealthMax_2))
			{
				Debug.Log("Cannot Unlock");
			}
		};

		transform.Find("MovementSpeed_2").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.TryUnlockSkill(PlayerSkills.SkillType.MovementSpeed_2);
		};

		transform.Find("Damage_2").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Damage_2);
		};

		transform.Find("HealthMax_3").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.TryUnlockSkill(PlayerSkills.SkillType.HealthMax_3);
		};

		transform.Find("MovementSpeed_3").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.TryUnlockSkill(PlayerSkills.SkillType.MovementSpeed_3);
		};

		transform.Find("Damage_3").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Damage_3);
		};

		transform.Find("Skill_1").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.TryUnlockSkill(PlayerSkills.SkillType.skill1);
		};

		transform.Find("Skill_2").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.TryUnlockSkill(PlayerSkills.SkillType.skill2);
		};

		transform.Find("Skill_3").GetComponent<Button_UI>().ClickFunc = () =>
		{
			playerSkills.TryUnlockSkill(PlayerSkills.SkillType.skill3);
		};

	}

	private void PlayerSkills_OnSkillPointChange(object sender, System.EventArgs e)
	{
		UpdateSkillPoints();
	}

	public void SetPlayerSkills(PlayerSkills playerSkills)
	{
		this.playerSkills = playerSkills;
		playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
		playerSkills.OnSkillPointChange += PlayerSkills_OnSkillPointChange;
		UpdateVisuals();
	}

	private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEvenetArgs e)
	{
		UpdateVisuals();
	}

	public void UpdateSkillPoints()
	{
		skillPointsText.SetText(playerSkills.GetSkillPoints().ToString());	
	}

	private void UpdateVisuals()
	{
		//if(playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.HealthMax_1))
		//{
		//	transform.Find("HealthMax_1").Find("image").GetComponent<Image>().material = null;
		//}
		//else if (playerSkills.CanUnlock(PlayerSkills.SkillType.HealthMax_1))
		//{ 
		//	transform.Find("HealthMax_1").Find("image").GetComponent<Image>().material = skillUnlockableMaterial;
		//}
		//else
		//{
		//	transform.Find("HealthMax_1").Find("image").GetComponent<Image>().material = skillLockedMaterial;
		//}
		
	}

}
