using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


// Interface for the enemy view
public interface ITowerView
{
    
}

public class TowerView: MonoBehaviour, ITowerView
{
    public TowerModel model;
    public CircleCollider2D coll;
    public Transform projectileSourceTransform;
    
    public Mob currentTarget;

    void Start()
    {
        SetTowerCollider();
        SetProjectileSource();

        //debugging
        DEVSetModel();
    }

    void Update()
    {
        
    }

    void SetTowerCollider()
    {
        coll.radius = model.radius;
    }

    void SetProjectileSource()
    {
        projectileSourceTransform = this.gameObject.transform.Find("ProjectileSource") as Transform;
        if (projectileSourceTransform == null)
        {
            //Debug.Log("Didn't find projectile source");
        }
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, coll.radius);
    }

    void DEVSetModel()
    {
        TowerModel _model = TowerModel.Factory.CreateTowerModel();
        this.model = _model;
    }
}

public interface ITowerViewFactory
{
    TowerView View { get; }
}

public class TowerViewFactory : ITowerViewFactory
{
    public TowerView View { get; private set; }

    public TowerViewFactory()
    { }
}