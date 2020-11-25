using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    //variables utilisée

    public GameObject enemyPrefab;
    private float spawnRangeZ = 20.0f;
    // Start is called before the first frame update
    void Start()

        // generateur des ennemies
    {
        InvokeRepeating("GenerateEnemy", 0, 5);
    }

    // Update is called once per frame
    Vector3 GenerateSpawnPosition()
        //position randowm des ennemies
    {
        
        float spawnZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        
        return new Vector3(20, 0, spawnZ);
    }
    void GenerateEnemy()

    {

        Vector3 spawnPosition = GenerateSpawnPosition();
        Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);

    }
    //Detruire GameObjects
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
}

}