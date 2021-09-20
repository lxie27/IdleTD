using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Mob
{
    // Start is called before the first frame update
    public override void Start()
    {
        health = 5f;
        speed = 5f;

        MobInitialization();
    }
}
