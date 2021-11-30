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

    public GameObject gemSlot;

    void Start()
    {
        UpdateComponents();
    }

    void Update()
    {
        
    }

    public void SetDisplayedGemToRarest()
    {
        if (model.gemsData.Count < 1)
        {
            return;
        }

        GemData rarestGem = model.gemsData[0];

        if (model.gemsData.Count == 1)
        {
            return;
        }

        //TODO a better sorting method for displayed gem
        foreach (GemData gem in model.gemsData)
        {
            if (gem.rarity > rarestGem.rarity)
            {
                rarestGem = gem;
            }
        }
    }

    void UpdateComponents()
    {
        SetTowerCollider();
        SetProjectileSource();
    }

    void SetTowerCollider()
    {
        coll.radius = model.radius;
    }

    void SetProjectileSource()
    {
        projectileSourceTransform = this.gameObject.transform.Find("ProjectileSource") as Transform;
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, model.radius);
    }
    public void UpdateModel(TowerModel _model)
    {
        model = _model;
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