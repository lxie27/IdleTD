using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public List<Mob> mobs;
    public float firstSpawnDelay;
    public float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        firstSpawnDelay = 3f;
        spawnDelay = 3f;
        InvokeRepeating("SpawnMobs", firstSpawnDelay, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawn then move
    void SpawnMobs()
    {
        Instantiate(mobs[Random.Range(0, mobs.Count)], this.transform.position, Quaternion.identity);
    }

}
