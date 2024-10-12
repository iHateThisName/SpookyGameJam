using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour {
    public GameObject zombiePrefab;
    private List<Transform> spawnPoints;
    private GameObject zombiesCollection;

    private int MaxSpawnAmount = 1;
    private int MinSpawnAmount = 1;

    void Start() {
        spawnPoints = new List<Transform>();

        GameObject[] spawns = GameObject.FindGameObjectsWithTag("ZombieSpawn");

        foreach (GameObject spawn in spawns) {
            spawnPoints.Add(spawn.transform);
        }
        zombiesCollection = new GameObject("Zombies");
        zombiesCollection.transform.parent = transform;

        //Get Max and Min Spawn Amount
        MaxSpawnAmount = GameManager.Instance.days;
        if (GameManager.Instance.days / 2 > 1) MinSpawnAmount = GameManager.Instance.days / 2;

        SpawnZombies();
    }

    void SpawnZombies() {
        foreach (Transform spawnPoint in spawnPoints) {
            int spawnAmount = Random.Range(MinSpawnAmount, MaxSpawnAmount + 1);
            //Debug.Log($"spawnAmount = {spawnAmount}, min = {MinSpawnAmount}, max = {MaxSpawnAmount}");
            for (int i = 0; i < spawnAmount; i++) {
                Vector2 randomOffset = new Vector2(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f));
                Vector2 spawnPosition = (Vector2)spawnPoint.position + randomOffset;
                Instantiate(zombiePrefab, spawnPosition, spawnPoint.rotation).transform.parent = zombiesCollection.transform;
            }
        }
    }
}
