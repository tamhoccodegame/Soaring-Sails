using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills
{
   public enum SkillType
	{
		skill1,
	}

	private List<SkillType> unlockedSkillTypeList;

	public PlayerSkills()
	{
		unlockedSkillTypeList = new List<SkillType>();
	}

	public void UnclockSkill(SkillType skillType)
	{
		unlockedSkillTypeList.Add(skillType);
	}

	public bool isSkillUnlocked(SkillType skillType)
	{
		return unlockedSkillTypeList.Contains(skillType);
	}
}
