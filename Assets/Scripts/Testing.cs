using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] public Player player;
	[SerializeField] public UI_SkillTree uiSkillTree;

	private void Start()
	{
		uiSkillTree.SetPlayerSkills(player.GetPlayerSkill());
	}
}
