using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using CodeMonkey.Utils;
using System;

public class LevelSystemAnimated
{
	public event EventHandler OnExperienceChanged;
	public event EventHandler OnLevelChanged;

	private LevelSystem levelSystem;
	private bool isAnimating;

	private int level;
	private float experience;
	private float experienceToNextLevel;

	public LevelSystemAnimated(LevelSystem levelSystem)
	{
		SetLevelSystem(levelSystem);

		FunctionUpdater.Create(() => Update());
	}

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

		level = levelSystem.GetLevelNumber();

		levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
		levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
    }

	private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
	{
		isAnimating = true;
	}

	private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
	{
		isAnimating = true;
	}

	public void Update()
	{
		if(isAnimating)
		{
			if(level < levelSystem.GetLevelNumber())
			{
				AddExperience();
			}
			else
			{
				if(experience < levelSystem.GetExperience())
				{
					AddExperience();
				}
				else
				{
					isAnimating = false;
				}
			}
		}
	}

	private void AddExperience()
	{
		experience++;
		if(experience >= experienceToNextLevel)
		{
			level++;
			experience = 0;
			if(OnLevelChanged != null)
			{
				OnLevelChanged(this, EventArgs.Empty);
			}
		}
		if(OnExperienceChanged != null)
		{
			OnExperienceChanged(this, EventArgs.Empty);
		}
	}

	public int GetLevelNumber()
	{
		return level;
	}

	public float GetExperienceNormalized()
	{
		return experience / experienceToNextLevel;
	}
}
