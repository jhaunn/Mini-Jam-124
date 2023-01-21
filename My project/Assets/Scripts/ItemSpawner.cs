using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

    //[SerializeField] private Vector3 minArea;
    //[SerializeField] private Vector3 maxArea;

    [SerializeField] private float spawnRadius;

    [SerializeField] private float minSpawnInterval;
    [SerializeField] private float maxSpawnInterval;

    private float currentSpawnInterval;

    private void Start()
    {
        currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        currentSpawnInterval -= Time.deltaTime;

        if (currentSpawnInterval <= 0f)
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
