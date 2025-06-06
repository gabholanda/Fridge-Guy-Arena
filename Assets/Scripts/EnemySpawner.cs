using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float minSpawnTime = 2.0f;
    [SerializeField]
    private float maxSpawnTime = 12.0f;


    private void Awake()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    public IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            float time = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(time);

            Instantiate(enemyPrefab, transform.position + new Vector3(0, 1.0f), Quaternion.identity);
        }
    }
}
