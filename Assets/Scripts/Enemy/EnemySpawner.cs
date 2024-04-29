using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float cooldownSpawn = .7f;
	private int countSpawnedEnemy = 0;
	[SerializeField] private float cooldownTimer = 0f;
    [SerializeField] private GameObject[] Enemy;
    [SerializeField] private Player player;
	[SerializeField] private Transform warningText;
	[SerializeField] private AudioSource audioSource;
    private LevelSystem levelSystem;
	private int playerLevel;
	private Transform UI;


	private void Start()
	{
		levelSystem = player.GetLevelSystem();
		levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
		UI = GameObject.Find("UI").GetComponent<Transform>();
		audioSource.Play();
		
	}

	private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
	{
		playerLevel = levelSystem.GetLevelNumber();
	}

	void Update()
    {

		Debug.Log(countSpawnedEnemy);
		cooldownTimer -= Time.deltaTime;

		Vector3 spawnLoc = player.transform.position + new Vector3(Random.Range(-4,4),Random.Range(-4,-4),0);
		if (countSpawnedEnemy >= 10)
		{ 
			StartCoroutine(Rest());
		}
		else
		{

			if (cooldownTimer <= 0)
			{
				if(playerLevel >= 3)
				{
					Instantiate(Enemy[Random.Range(0, 3)], spawnLoc, Quaternion.identity);
					countSpawnedEnemy++;
				}
				else
				{
					Instantiate(Enemy[Random.Range(0, 2)], spawnLoc, Quaternion.identity);
					countSpawnedEnemy++;
				}

				cooldownTimer = cooldownSpawn;
			}
		}
    } 

	IEnumerator Rest()
	{
		yield return new WaitForSeconds(30f);
		countSpawnedEnemy = 0;
	}
 
}
