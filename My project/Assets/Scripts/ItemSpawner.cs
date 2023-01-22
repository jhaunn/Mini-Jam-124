using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

    [SerializeField] private float spawnRadius;

    [SerializeField] private float minSpawnInterval;
    [SerializeField] private float maxSpawnInterval;

    private float currentSpawnInterval;

    public bool CanSpawn { get; set; }

    private void Start()
    {
        CanSpawn = true;

        currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        currentSpawnInterval -= Time.deltaTime;

        if (currentSpawnInterval <= 0f && CanSpawn)
        {
            Instantiate(items[Random.Range(0, items.Length)], transform.position + (Random.insideUnitSphere * spawnRadius), Quaternion.identity);

            currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
