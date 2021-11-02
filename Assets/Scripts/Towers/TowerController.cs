using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for the enemy view
public interface ITowerController
{

}
[System.Serializable]
public class TowerController: MonoBehaviour
{
    public TowerView view;
    public TowerModel model;
    public List<Vector2> path;
    List<Mob> mobsInRange;

    float cdTimer = -1f;

    void Start()
    {
        mobsInRange = new List<Mob>();
        path = GameObject.Find("Grid").GetComponent<GridMap>().pathCells;
        model = view.model;
    }

    void Update()
    {
        UpdateMobsInRange();
        TargetSelection();
        AttackOnCooldown();
    }

    // Pretty expensive call, TODO optimize mob in individual tower ranges
    void UpdateMobsInRange()
    {
        mobsInRange.Clear();
        Collider2D[] allColliders = Physics2D.OverlapCircleAll((Vector2)this.transform.position, model.radius);

        foreach (var coll in allColliders)
        {
            if (coll.tag == "Mob")
            {
                mobsInRange.Add(coll.gameObject.GetComponent<Mob>());
            }

        }
    }

    void AttackOnCooldown()
    {
        if (Time.time > cdTimer)
        {
            cdTimer = Time.time + model.attackSpeed;

            if (view.currentTarget != null)
            {
                ProjectileFactory.Spawn(view.projectileSourceTransform, view.currentTarget.transform);
            }
        }
    }

    // Currently just attacks the oldest target in range, override for different target selection
    public virtual void TargetSelection()
    {
        if (mobsInRange.Count < 1)
        {
            view.currentTarget = null;
            return;
        }

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

