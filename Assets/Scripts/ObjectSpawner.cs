using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawners : MonoBehaviour
{
    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;

    [SerializeField] private int waveNumber;
    [SerializeField] private List<Wave> waves;

    [System.Serializable]

    public class Wave
    {
        public GameObject prefab;
        public float spawnTimer;
        public float spawnInterval;
        public int objectsPerWave;
        public int spawnedObjectsCount;

    }
    void Update()
    {
        waves[waveNumber].spawnTimer += Time.deltaTime * PlayerController.Instance.boost;
        if (waves[waveNumber].spawnTimer >= waves[waveNumber].spawnInterval)
        {
            waves[waveNumber].spawnTimer = 0;
            SpawnObject();
        }

        if (waves[waveNumber].spawnedObjectsCount >= waves[waveNumber].objectsPerWave)
        {
            waves[waveNumber].spawnedObjectsCount = 0;
            waveNumber++;
            if (waveNumber >= waves.Count)
            {
                waveNumber = 0;
            }
        }

       
    }

    private void SpawnObject()
    {
        Instantiate(waves[waveNumber].prefab, RandomSpawnPosition(), transform.rotation);
        waves[waveNumber].spawnedObjectsCount++;
    }

    public Vector2 RandomSpawnPosition()
    {
        Vector2 spawnPoint;

        spawnPoint.x = minPos.position.x ;
        spawnPoint.y = Random.Range(minPos.position.y, maxPos.position.y);

        return spawnPoint;
    }
}
