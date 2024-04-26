using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerSkills
{
	public event EventHandler OnSkillPointChange;
	public event EventHandler<OnSkillUnlockedEvenetArgs> OnSkillUnlocked;
	public class OnSkillUnlockedEvenetArgs : EventArgs
	{
		public SkillType skillType;
	}

	public enum SkillType
	{
		None,
		skill1,
		skill2,
		skill3,
		HealthMax_1,
		HealthMax_2,
		HealthMax_3,
		MovementSpeed_1,
		MovementSpeed_2,
		MovementSpeed_3,
		Damage_1,
		Damage_2,
		Damage_3,
	}

	private List<SkillType> unlockedSkillTypeList;
	private int skillPoints = 1000;

	public PlayerSkills()
	{
		unlockedSkillTypeList = new List<SkillType>();
	}

	public void AddSkillPoint()
	{
		skillPoints++;
		OnSkillPointChange?.Invoke(this, EventArgs.Empty);
	}

	public int GetSkillPoints()
	{
		return skillPoints;
	}

	private void UnlockSkill(SkillType skillType)
	{
		if (!IsSkillUnlocked(skillType))
		{
			unlockedSkillTypeList.Add(skillType);
			OnSkillUnlocked?.Invoke(this, new OnSkillUnlockedEvenetArgs { skillType = skillType });
		}

	}

	public bool IsSkillUnlocked(SkillType skillType)
	{
		return unlockedSkillTypeList.Contains(skillType);
	}

	public bool CanUnlock(SkillType skillType)
	{
		SkillType skillRequirement = GetSkillRequirement(skillType);

		if (!IsSkillUnlocked(skillType))
		{
			if (skillRequirement != SkillType.None)
			{
				if (IsSkillUnlocked(skillRequirement))
				{
					return true;
				}
				else
				{
					Debug.Log("Upgrade " + skillRequirement + " first");
					return false;
				}
			}
			else
			{
				return true;
			}
		}
		else
		{
			return false;
		}

	}

	public SkillType GetSkillRequirement(SkillType skillType)
	{
		switch (skillType)
		{
			case SkillType.HealthMax_3: return SkillType.HealthMax_2;
			case SkillType.HealthMax_2: return SkillType.HealthMax_1;
			case SkillType.Damage_3: return SkillType.Damage_2;
			case SkillType.Damage_2: return SkillType.Damage_1;
			case SkillType.MovementSpeed_3: return SkillType.MovementSpeed_2;
			case SkillType.MovementSpeed_2: return SkillType.MovementSpeed_1;
		}
		return SkillType.None;
	}

	public bool TryUnlockSkill(SkillType skillType)
	{
		SkillType skillRequirement = GetSkillRequirement(skillType);
		if (CanUnlock(skillType))
		{
			if (skillPoints > 0)
			{
				skillPoints--;
				UnlockSkill(skillType);
				OnSkillPointChange?.Invoke(this, EventArgs.Empty);
				return true;
			}
			else
			{
				return false;
			}

		}
		else
		{
			return false;
		}
	}
}
