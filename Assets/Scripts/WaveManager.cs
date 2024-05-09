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
    private bool wasSpawnBoss = false;
    private enum Wave
    {
        wave1,
        wave2,
        win
    }
    private Wave currentWave = Wave.wave1;
    private void Start()
    {
        numberEnemy = enemyMax;
        audioManager = GetComponent<AudioManager>();
    }

    private void Update()
    {
       /*if(!wasSpawn && numberEnemy > 0)
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
           timeline.SetActive(true);
		}*/
       switch (currentWave)
        {
            case Wave.wave1:
                wave1.SetActive(true);
                if (!wasSpawn && numberEnemy > 0)
                {
                    wasSpawn = true;
                    StartCoroutine(SpawnDelay());
                }
                else if (numberEnemy < 1 && !AnyEnemiesLeft())
                {
                    currentWave = Wave.wave2;
                    numberEnemy = enemyMax;
                }
                break;
            case Wave.wave2:
                wave2.SetActive(true);
                if (!wasSpawn && numberEnemy > 0)
                {
                    wasSpawn = true;
                    StartCoroutine(SpawnDelay());
                }
                if (!wasSpawnBoss)
                {
                    wasSpawnBoss = true;
                    SpawnBoss();
                }
                else if (numberEnemy < 1 && !AnyEnemiesLeft())
                {
                    currentWave = Wave.win;
                }
                break;
            case Wave.win:
                timeline.SetActive(true);
                break;
        }
    }

    private bool AnyEnemiesLeft()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length > 0;
    }

    private void SpawnBoss()
    {
        ListEnemyLive.Add(Instantiate(boss, spawn2.transform.position, Quaternion.identity));
        healthBar.SetActive(true);
        audioSource.clip = audioManager.GetAudioClip("bossmusic");
        audioSource.volume = 0.1f;
        audioSource.pitch = 1.1f;
        audioSource.Play();
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
