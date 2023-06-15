using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private Vector2 minPosition;

    [SerializeField]
    private Vector2 maxPosition;

    [SerializeField]
    private float rateSpawn;

    [SerializeField]
    private int numEnemyMax;

    private int currentNumEnemies = 0;

    private bool invoking = false;

    private void Start()
    {
        invoking = true;
        InvokeRepeating(nameof(SpawnEnemy), 0, rateSpawn);
    }

    private void SpawnEnemy()
    {
        GameObject currentEnemy = Instantiate(enemyPrefab, transform);
        Random.seed = Random.Range(-10, 10);

        Vector3 pos = new Vector3();
        pos.x = Random.Range(minPosition.x, maxPosition.x);
        pos.y = 0.5f;
        pos.z = Random.Range(minPosition.y, maxPosition.y);
        currentEnemy.transform.position = pos;


        print(pos);
        
        
        currentNumEnemies++;

        if (currentNumEnemies >= numEnemyMax)
        {
            invoking = false;
            CancelInvoke();
        }
    }

    public void OnEnemyDie()
    {
        currentNumEnemies--;
        if (!invoking)
        {
            invoking = true;
            InvokeRepeating(nameof(SpawnEnemy), 0, rateSpawn);
        }
    }

}
