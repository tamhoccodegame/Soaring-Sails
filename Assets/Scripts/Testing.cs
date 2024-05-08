using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Player player;
	[SerializeField] private UI_SkillTree uiSkillTree;
	[SerializeField] private LevelBar levelBar;

	private void Awake()
	{
		uiSkillTree.SetPlayerSkills(player.GetPlayerSkill());
		LevelSystem levelSystem = new LevelSystem();
		levelBar.SetLevelSystem(levelSystem);
		player.SetLevelSystem(levelSystem);
		

		//ItemWorld.SpawnItemWorld(new Vector2(5,5), new Item { itemType = Item.ItemType.Weapon, amount = 1 });
		//ItemWorld.SpawnItemWorld(new Vector2(5, 6), new Item { itemType = Item.ItemType.Medkit, amount = 1 });


	}
}
