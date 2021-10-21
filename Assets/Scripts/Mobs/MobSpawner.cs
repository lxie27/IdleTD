using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public List<Mob> mobs;
    public float spawnDelay = 1f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0);
        StartCoroutine(SpawnMobs(spawnDelay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawn then move
    IEnumerator SpawnMobs(float delay)
    {
        for (int i = 0; i < mobs.Count; i++)
        {
            Instantiate(mobs[i], this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }

}
