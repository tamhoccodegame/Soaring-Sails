using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills
{
	public event EventHandler<OnSkillUnlockedEvenetArgs> OnSkillUnlocked;
	public class OnSkillUnlockedEvenetArgs : EventArgs
	{
		public SkillType skillType;
	}

   public enum SkillType
	{
		HealthMax_1,
		HealthMax_2,
		HealthMax_3,
		MovementSpeed_1,
		MovementSpeed_2,
		MovementSpeed_3,
		Damage_1,
		Damage_2,
		Damage_3,
		Damage_4,
	}

	private List<SkillType> unlockedSkillTypeList;

	public PlayerSkills()
	{
		unlockedSkillTypeList = new List<SkillType>();
	}

	public void UnlockSkill(SkillType skillType)
	{
		if (!isSkillUnlocked(skillType))
		{
			unlockedSkillTypeList.Add(skillType);
			OnSkillUnlocked?.Invoke(this, new OnSkillUnlockedEvenetArgs { skillType = skillType });
		}
		
	}

	public bool isSkillUnlocked(SkillType skillType)
	{
		return unlockedSkillTypeList.Contains(skillType);
	}
}
