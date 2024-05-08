using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSkills playerSkills;
    private PlayerController1 playerController1;
    private LevelSystem levelSystem;
    private Inventory inventory;
    private Equipment equipment;
    private int coin;
    private TextMeshProUGUI coinText;

    public UI_StatPlayerTest ui_StatPlayerTest;

    [SerializeField] private UI_Inventory uiInventory;
	[SerializeField] private UI_SkillTree uiSkillTree;
	[SerializeField] private LevelBar levelBar;
    [SerializeField] private CraftingSystem craftingSystem;
    [SerializeField] private UI_Equipment uiEquipment;

    public ParticleSystem levelUpEffect;
    AudioManager audioManager;

	private void Start()
    {
		playerSkills = new PlayerSkills();
		inventory = new Inventory();
		inventory.OnItemUsed += Inventory_OnItemUsed;


        equipment = new Equipment();
        equipment.SetInventory(inventory);

        uiEquipment.SetEquipment(equipment);

        uiInventory.SetInventory(inventory);
        uiInventory.SetEquipment(equipment);
        uiInventory.SetPlayer(this);
		uiSkillTree.SetPlayerSkills(playerSkills);

		LevelSystem levelSystem = new LevelSystem();
		levelBar.SetLevelSystem(levelSystem);
		SetLevelSystem(levelSystem);

        craftingSystem.SetInventory(inventory);
        playerController1 = GetComponentInParent<PlayerController1>();
        
		playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
		audioManager = GetComponent<AudioManager>();

        coinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
	}

	private void Inventory_OnItemUsed(object sender, Inventory.OnItemUsedEventArgs e)
	{
        playerController1.health += e.plusHealth;
        Mathf.Clamp(playerController1.health, 0, 100);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();

        if(itemWorld == null)
        {
            return;
        }

		Item item = itemWorld.GetItem();

		if (item.itemType == Item.ItemType.Coin)
        {
            coin += item.amount;
            coinText.text = coin.ToString();
			itemWorld.DestroySelf();
			return;
        }

        inventory.AddItem(item);
        itemWorld.DestroySelf();
       
	}
    
  
	public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

		levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    public LevelSystem GetLevelSystem()
    {
        return levelSystem;
    }

	public void AddExperienceFromEnemy(int amount)
	{
		levelSystem.AddExperience(amount);
	}

	private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
	{
        levelUpEffect.Play();
        audioManager.PlayAudioClip("levelup");
        playerSkills.AddSkillPoint(); 
	}

	private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEvenetArgs e)
	{
		switch(e.skillType)
        {
            case PlayerSkills.SkillType.HealthMax_1:
                SetHealthAmountMax(110);
                break;
            case PlayerSkills.SkillType.HealthMax_2:
                SetHealthAmountMax(120);
                break;
			case PlayerSkills.SkillType.HealthMax_3:
				SetHealthAmountMax(140);
				break;
			case PlayerSkills.SkillType.MovementSpeed_1:
                SetMovementSpeed(6);
				break;
			case PlayerSkills.SkillType.MovementSpeed_2:
				SetMovementSpeed(7);
				break;
			case PlayerSkills.SkillType.MovementSpeed_3:
				SetMovementSpeed(9);
				break;

			case PlayerSkills.SkillType.Damage_1:
                SetDamage(30);
				break;

			case PlayerSkills.SkillType.Damage_2:
				SetDamage(35);
				break;

			case PlayerSkills.SkillType.Damage_3:
				SetDamage(45);
				break;

		}
        ui_StatPlayerTest.UpdateStatText();
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
        playerController1.health = amount;
    }

    private void SetMovementSpeed(float speed)
    {
        playerController1.moveSpeed = speed;
    }

    private void SetDamage(int damage)
    {
        playerController1.damage = damage;
    }
}
