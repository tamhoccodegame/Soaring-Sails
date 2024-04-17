using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class LevelBar : MonoBehaviour
{
    private TextMeshProUGUI levelText;
    private Image experienceBarSlider;
	private LevelSystem levelSystem;

	private void Awake()
	{
		levelText = transform.Find("levelText").GetComponent<TextMeshProUGUI>();
		experienceBarSlider = transform.Find("ExpBar").Find("Fill").GetComponent<Image>();
	
		transform.Find("experience500").GetComponent<Button_UI>().ClickFunc = () => levelSystem.AddExperience(500);

	}

	private void SetExperienceBarSize(float experienceNormalized)
	{
		experienceBarSlider.fillAmount = experienceNormalized;
	}

	private void SetLevelNumber(int levelNumber)
	{
		levelText.text = "LEVEL " + (levelNumber + 1);
	}

	
	public void SetLevelSystem(LevelSystem levelSystem)
	{
		this.levelSystem = levelSystem;

		SetLevelNumber(levelSystem.GetLevelNumber());
		SetExperienceBarSize(levelSystem.GetExperienceNormalized());

		levelSystem.OnExperienceChanged += LevelSystemAnimated_OnExperienceChanged;
		levelSystem.OnLevelChanged += LevelSystemAnimated_OnLevelChanged;
	}

	private void LevelSystemAnimated_OnLevelChanged(object sender, System.EventArgs e)
	{
		SetLevelNumber(levelSystem.GetLevelNumber());
	}

	private void LevelSystemAnimated_OnExperienceChanged(object sender, System.EventArgs e)
	{
		SetExperienceBarSize(levelSystem.GetExperienceNormalized());
	}
}
