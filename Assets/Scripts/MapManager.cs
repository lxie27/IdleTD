using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<Mob> totalMobs;
    public List<Mob> activeMobs;
    public Vector2 pathStartPosition;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("SPAWNING 3 MOBS");
        StartCoroutine(SpawnMobs());
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Spawn then move
    IEnumerator SpawnMobs()
    {
        foreach (var mob in totalMobs)
        {
            Debug.Log("Spawning a mob");
            Instantiate(mob, pathStartPosition, Quaternion.identity, this.transform);
            mob.isMoving = true;
            activeMobs.Add(mob);
            yield return new WaitForSeconds(1);
        }
    }

}
