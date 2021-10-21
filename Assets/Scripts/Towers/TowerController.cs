using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Interface for the enemy view
public interface ITowerController
{

}
[System.Serializable]
public class TowerController: MonoBehaviour
{
    public TowerView view;

    List<Mob> mobsInRange;
    float cdTimer = -1f;

    void Start()
    {
        mobsInRange = new List<Mob>();
    }

    void Update()
    {
        foreach (var mob in mobsInRange)
        {
            Debug.Log(mob.name);
        }

        if (mobsInRange.Count > 0)
        {
            TargetSelection();
            Debug.Log("Attacking target: " + view.currentTarget);
            AttackOnCooldown();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mob")
        {
            Debug.Log("Mob entered range.");
            mobsInRange.Add(collision.gameObject.GetComponent<Mob>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Mob")
        {
            Debug.Log("Mob exited range.");
            mobsInRange.Remove(collision.gameObject.GetComponent<Mob>());
        }
    }

    void AttackOnCooldown()
    {
        if (Time.time > cdTimer)
        {
            cdTimer = Time.time + view.model.attackSpeed;
            ProjectileFactory.Spawn(view.projectileSourceTransform, view.currentTarget.transform);
        }
    }

    // Currently just attacks the oldest target in range, override for different target selection
    public virtual void TargetSelection()
    {
        if (mobsInRange.Count > 0)
        {
            view.currentTarget = mobsInRange[0];
        }
    }
}


public interface ITowerControllerFactory
{
    TowerController Controller { get; }
}


