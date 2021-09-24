using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Mob
{
    // Start is called before the first frame update
    public override void Start()
    {
        health = 10f;
        speed = 2f;

        MobInitialization();
    }
}