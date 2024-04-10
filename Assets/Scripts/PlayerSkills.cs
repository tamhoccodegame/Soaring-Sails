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

	public void UnlockSkill(SkillType skillType)
	{
		unlockedSkillTypeList.Add(skillType);
		Debug.Log(isSkillUnlocked(skillType));	
	}

	public bool isSkillUnlocked(SkillType skillType)
	{
		return unlockedSkillTypeList.Contains(skillType);
	}
}
