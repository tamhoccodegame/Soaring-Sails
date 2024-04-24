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
	[SerializeField] private SkillUnlockPath[] skillUnlockPathArray;
	[SerializeField] private Sprite lineSprite;
	[SerializeField] private Sprite lineGlowSprite;

	private PlayerSkills playerSkills;
	private List<SkillButton> skillButtonList;
	private TextMeshProUGUI skillPointsText;
	private void Awake()
	{
		
	}

	private void PlayerSkills_OnSkillPointChange(object sender, System.EventArgs e)
	{
		UpdateSkillPoints();
	}

	public void SetPlayerSkills(PlayerSkills playerSkills)
	{
		this.playerSkills = playerSkills;

		skillButtonList = new List<SkillButton>();
		skillButtonList.Add(new SkillButton(transform.Find("HealthMax_1"), playerSkills, PlayerSkills.SkillType.HealthMax_1, skillUnlockableMaterial, skillLockedMaterial));
		skillButtonList.Add(new SkillButton(transform.Find("HealthMax_2"), playerSkills, PlayerSkills.SkillType.HealthMax_2, skillUnlockableMaterial, skillLockedMaterial));
		skillButtonList.Add(new SkillButton(transform.Find("HealthMax_3"), playerSkills, PlayerSkills.SkillType.HealthMax_3, skillUnlockableMaterial, skillLockedMaterial));
		skillButtonList.Add(new SkillButton(transform.Find("MovementSpeed_1"), playerSkills, PlayerSkills.SkillType.MovementSpeed_1, skillUnlockableMaterial, skillLockedMaterial));
		skillButtonList.Add(new SkillButton(transform.Find("MovementSpeed_2"), playerSkills, PlayerSkills.SkillType.MovementSpeed_2, skillUnlockableMaterial, skillLockedMaterial));
		skillButtonList.Add(new SkillButton(transform.Find("MovementSpeed_3"), playerSkills, PlayerSkills.SkillType.MovementSpeed_3, skillUnlockableMaterial, skillLockedMaterial));
		skillButtonList.Add(new SkillButton(transform.Find("Damage_1"), playerSkills, PlayerSkills.SkillType.Damage_1, skillUnlockableMaterial, skillLockedMaterial));
		skillButtonList.Add(new SkillButton(transform.Find("Damage_2"), playerSkills, PlayerSkills.SkillType.Damage_2, skillUnlockableMaterial, skillLockedMaterial));
		skillButtonList.Add(new SkillButton(transform.Find("Damage_3"), playerSkills, PlayerSkills.SkillType.Damage_3, skillUnlockableMaterial, skillLockedMaterial));

		playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
		playerSkills.OnSkillPointChange += PlayerSkills_OnSkillPointChange;
		UpdateVisuals();
	}

	private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEvenetArgs e)
	{
		UpdateVisuals();
	}

	private void UpdateVisuals()
	{
		foreach(SkillButton skillButton in skillButtonList)
		{
			skillButton.UpdateVisuals();
		}

		//foreach(SkillUnlockPath skillUnlockPath in skillUnlockPathArray)
		//{
		//	foreach(Image linkImage in skillUnlockPath.linkImageArray)
		//	{
		//		linkImage.color = new Color(.5f, .5f, .5f);
		//		linkImage.sprite = lineSprite;
		//	}
		//}

		foreach (SkillUnlockPath skillUnlockPath in skillUnlockPathArray)
		{
			if (playerSkills.IsSkillUnlocked(skillUnlockPath.skillType) || playerSkills.CanUnlock(skillUnlockPath.skillType))
			{
				foreach (Image linkImage in skillUnlockPath.linkImageArray)
				{
					linkImage.color = Color.white;
					linkImage.sprite = lineGlowSprite;
				}
			}
			else
			{
				foreach (Image linkImage in skillUnlockPath.linkImageArray)
				{
					linkImage.color = new Color(.5f, .5f, .5f);
					linkImage.sprite = lineSprite;
				}
			}
		}
	}

	public void UpdateSkillPoints()
	{
		skillPointsText.SetText(playerSkills.GetSkillPoints().ToString());	
	}

	

	private class SkillButton
	{
		private Transform transform;
		private Image image;
		private PlayerSkills playerSkills;
		private PlayerSkills.SkillType skillType;
		private Material skillUnlockableMaterial;
		private Material skillLockedMaterial;

		public SkillButton(Transform transform, PlayerSkills playerSkills, PlayerSkills.SkillType skillType, Material skillUnlockableMaterial, Material skillLockedMaterial)
		{
			this.transform = transform;
			this.playerSkills = playerSkills;
			this.skillType = skillType;
			this.image = transform.Find("Image").GetComponent<Image>();

			transform.GetComponent<Button_UI>().ClickFunc = () =>
			{
				playerSkills.TryUnlockSkill(skillType);
			};
		}

		public void UpdateVisuals()
		{
			if (playerSkills.IsSkillUnlocked(skillType))
			{
				image.color = Color.white;
			}
			else
			{
				if (playerSkills.CanUnlock(skillType))
				{
					image.color = new Color(.1f, .1f, .1f);
				}
				else
				{
					image.color = Color.black;
				}
			}
		}
	}

	[System.Serializable]
	public class SkillUnlockPath
	{
		public PlayerSkills.SkillType skillType;
		public Image[] linkImageArray;
	}
}
