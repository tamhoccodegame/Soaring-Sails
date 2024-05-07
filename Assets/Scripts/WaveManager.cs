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
    public GameObject Boss;
    private int numberOfEnemiesToSpawn = 2;
    private float spawnRadius = 2f;
    public int numberEnemy = 40;
    public float spawnDelay;
    private bool wasSpawn = false;

    private void Start()
    {
        wave1.SetActive(true);
    }

    private void Update()
    {
       if(!wasSpawn && numberEnemy > 0)
        {
            wasSpawn = true;
            StartCoroutine(SpawnDelay());
        }
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
            Instantiate(RandomEnemy(), spawnPosition, Quaternion.identity);
        }
        numberEnemy -= numberOfEnemiesToSpawn;
    }

    private GameObject RandomEnemy()
    {
        int randomIndex = Random.Range(0, enemyList.Length);
        return enemyList[randomIndex];
    }
}
