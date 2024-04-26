using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerSkills playerSkills;
    private PlayerController1 playerController1;
    private LevelSystem levelSystem;
    public Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private CraftingSystem craftingSystem;

    public ParticleSystem Dust;

	void Start()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        uiInventory.SetPlayer(this);
        craftingSystem.SetInventory(inventory);
        playerController1 = GetComponent<PlayerController1>();
        playerSkills = new PlayerSkills();
		playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
	}
    
	public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

		levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

	private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
	{
        Dust.Play();
	}

	private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEvenetArgs e)
	{
		switch(e.skillType)
        {
            case PlayerSkills.SkillType.HealthMax_1:
                SetHealthAmountMax(110);
                Debug.Log("New health = 110");
                break;
            case PlayerSkills.SkillType.HealthMax_2:
                SetHealthAmountMax(120);
                break;
			case PlayerSkills.SkillType.HealthMax_3:
				SetHealthAmountMax(140);
				break;
			case PlayerSkills.SkillType.MovementSpeed_1:
                SetMovementSpeed(10);
				break;
			case PlayerSkills.SkillType.MovementSpeed_2:
				SetMovementSpeed(15);
				break;
			case PlayerSkills.SkillType.MovementSpeed_3:
				SetMovementSpeed(20);
				break;

			case PlayerSkills.SkillType.Damage_1:
                SetDamage(30);
				break;

			case PlayerSkills.SkillType.Damage_2:
				SetDamage(30);
				break;

			case PlayerSkills.SkillType.Damage_3:
				SetDamage(30);
				break;

		}
	}

	// Update is called once per frame
	void Update()
    {
    //    if(Input.GetKeyDown(KeyCode.J))
    //    {
    //        if(CanUseSkill1())
    //        {
				//// vi du day la skill
				//Vector3 newLocation = new Vector3(1,1,0); 
    //            transform.localPosition += newLocation;
    //        }
    //    }
    }
    

    public PlayerSkills GetPlayerSkill()
    {
        return playerSkills;
    }

    //public bool CanUseSkill1()
    //{
    //    return playerSkills.isSkillUnlocked(PlayerSkills.SkillType.skill1);
    //}

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void SetHealthAmountMax(int amount)
    {

    }

    private void SetMovementSpeed(float speed)
    {
        playerController1.SetPlayerSpeed(speed);
    }

    private void SetDamage(int damage)
    {

    }
}
