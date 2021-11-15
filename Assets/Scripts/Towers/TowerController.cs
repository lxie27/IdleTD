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

    float cdTimer = 0f;

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
    public void UpdateModel(TowerModel _model)
    {
        model = _model;
        view.UpdateModel(model);
    }

    void AttackOnCooldown()
    {
        if (Time.time > cdTimer && view.currentTarget != null)
        {
            ProjectileFactory.Spawn(view.projectileSourceTransform, view.currentTarget.transform);
            cdTimer = Time.time + model.attackSpeed;
        }
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

    // Currently just attacks the oldest target in range, override for different target selection
    public virtual void TargetSelection()
    {
        if (mobsInRange.Count < 1)
        {
            view.currentTarget = null;
            return;
        }
        else if (mobsInRange.Count == 1)
        {
            view.currentTarget = mobsInRange[0];
            return;
        }

        Mob farthestMob = mobsInRange[0];

        //gets max index, this will be the mob with the "furthest" cell in the path
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

