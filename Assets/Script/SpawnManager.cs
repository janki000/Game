using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(50, 0, 0);
    public float startDelay = 2;
    public float intervale = 1.5f;
    private PlayerController playerControllerScript;

    public float spawnRange = 9.0f;

    // Start is called before the first frame updateazs12
    void Start()
    {
        InvokeRepeating("obstacle", startDelay, intervale);
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
    }
    void obstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, transform.rotation);
        }
    }
    Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnX, 0, spawnZ);
    }
    void GenerateEnemy()
    {
        Vector3 spawnPosition = GenerateSpawnPosition();
        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
