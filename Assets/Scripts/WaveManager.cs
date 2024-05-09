using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject wave1;
    public GameObject wave2;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject[] enemyList;
    public GameObject boss;
    public GameObject healthBar;
    public GameObject timeline;
    private int numberOfEnemiesToSpawn = 2;
    private float spawnRadius = 2f;
    public int enemyMax = 10;
    public int numberEnemy;
    public float spawnDelay;
    private bool wasSpawn = false;
    private List<GameObject> ListEnemyLive = new List<GameObject>();
    public AudioSource audioSource;
    private AudioManager audioManager;
    private void Start()
    {
        wave1.SetActive(true);
        numberEnemy = enemyMax;
        audioManager = GetComponent<AudioManager>();
    }

    private void Update()
    {
       if(!wasSpawn && numberEnemy > 0)
       {
            wasSpawn = true;
            StartCoroutine(SpawnDelay());
        }
        else if (numberEnemy < 1 && AllEnemiesDead())
        {
            wave2.SetActive(true);
            numberEnemy = enemyMax;
            SpawnBoss();
        }
        else
        {
            //win thi se kich hoat cutscene win, em coi lai dieu kien khuc nay
           // timeline.SetActive(true);
		}
    }

    private bool AllEnemiesDead()
    {
        foreach (var enemy in ListEnemyLive)
        {
            if (enemy != null)
            {
                return false;
            }
        }

        return true;
    }

    private void SpawnBoss()
    {
        Instantiate(boss, spawn2.transform.position, Quaternion.identity);
        audioSource.clip = audioManager.GetAudioClip("bossmusic");
        audioSource.volume = 0.1f;
        audioSource.pitch = 1.1f;
        audioSource.Play();
		healthBar.SetActive(true);
	}

    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnEnemy(spawn1);
        SpawnEnemy(spawn2);
        SpawnEnemy(spawn3);
        SpawnEnemy(spawn4);
        wasSpawn = false;
    }

    private void SpawnEnemy(GameObject location)
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfEnemiesToSpawn;
            Vector3 spawnPosition = location.transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * spawnRadius;
            ListEnemyLive.Add(Instantiate(RandomEnemy(), spawnPosition, Quaternion.identity));
        }
        numberEnemy -= numberOfEnemiesToSpawn;
    }

    private GameObject RandomEnemy()
    {
        int randomIndex = Random.Range(0, enemyList.Length);
        return enemyList[randomIndex];
    }
}
