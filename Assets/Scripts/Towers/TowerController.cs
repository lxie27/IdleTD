using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

// Interface for the enemy view
public interface ITowerController
{

}
[System.Serializable]
public class TowerController: MonoBehaviour
{
    public TowerView view;
    public List<Vector2> path;
    List<Mob> mobsInRange;

    float cdTimer = -1f;

    void Start()
    {
        mobsInRange = new List<Mob>();
        path = GameObject.Find("Grid").GetComponent<GridMap>().pathCells;
    }

    void Update()
    {
        if (mobsInRange.Count > 0)
        {
            if (view.currentTarget == null)
            {
                TargetSelection();
            }
            AttackOnCooldown();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mob")
        {
            mobsInRange.Add(collision.gameObject.GetComponent<Mob>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Mob")
        {
            if (collision.gameObject.GetComponent<Mob>() == view.currentTarget)
            {
                view.currentTarget = null;
            }
            mobsInRange.Remove(collision.gameObject.GetComponent<Mob>());
        }
    }

    void AttackOnCooldown()
    {
        if (Time.time > cdTimer)
        {
            cdTimer = Time.time + view.model.attackSpeed;

            if (view.currentTarget != null)
            {
                ProjectileFactory.Spawn(view.projectileSourceTransform, view.currentTarget.transform);
            }
        }
    }

    // Currently just attacks the oldest target in range, override for different target selection
    public virtual void TargetSelection()
    {
        Mob farthestMob = mobsInRange[0];
        //gets max index, this will be the "furthest" cell in the path
        foreach (Mob mob in mobsInRange)
        {
            if (mob.currentCell > farthestMob.currentCell)
            {
                farthestMob = mob;
            }
        }
        view.currentTarget = farthestMob;
    }
}


public interface ITowerControllerFactory
{
    TowerController Controller { get; }
}


