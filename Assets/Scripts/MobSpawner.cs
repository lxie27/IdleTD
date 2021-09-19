using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public List<Mob> mobs;
    public float spawnDelay = .02f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(SpawnMobs(spawnDelay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawn then move
    IEnumerator SpawnMobs(float delay)
    {
        foreach (var mob in mobs)
        {
            Debug.Log("Spawning a mob");
            Instantiate(mob, this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }

}
