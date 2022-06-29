using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public float spawnRange;

    public float minSpawnTime;
    public float maxSpawnTime;
    private float lastSpawnTime;
    private float spawnTime;
    

    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        UpdateSpawnTime();
    }

    void UpdateSpawnTime()
    {
        lastSpawnTime = Time.time;
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastSpawnTime + spawnTime)
        {
            Spawn();
        }
    }

    Vector3 SpawnRange()
    {
        return new Vector3(Random.Range(-spawnRange, spawnRange),0, 116);
    }

    void Spawn()
    {
        Instantiate(zombie, SpawnRange(), Quaternion.identity);
        UpdateSpawnTime();
    }

}
