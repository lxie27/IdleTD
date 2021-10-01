using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum GemModifier
{
    None                    = 0,

    //Common modifiers      = 001-099
    AttackSpeed             = 001,
    AttackDamage            = 002,
    RangeIncrease           = 003,

    //Rare modifiers        = 101-199
    AreaOfEffectDamage      = 101,
    ProjectileCountIncrease = 102,


    //Epic modifiers        = 201-299
    VulnerableProjectiles   = 201,
    SlowingProjectiles      = 202,

    //Legendary modifiers   = 301-399
    FlamethrowerAttack      = 301,
    LaserRayAttack          = 302,
    ArcingAttack            = 303,

    //Mythical modifiers    = 401-499
    DuplicateTower          = 401,

}