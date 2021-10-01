using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Tower data
    public float damage;
    public float radius;
    public float attackSpeed;
    List<Gem> gems;

    float cdTimer = -1f;
    GameObject projectilePrefab;
    GameObject currentTarget;
    CircleCollider2D coll;
    Transform projectileSource;

    List<GemData> gemsData;

    public TowerData towerData;

    // Start is called before the first frame update
    void Start()
    {
        coll = this.gameObject.GetComponent<CircleCollider2D>();
        coll.radius = radius;
        projectileSource = this.gameObject.transform.Find("ProjectileSource") as Transform;
        if (projectileSource == null)
        {
            Debug.Log("Didn't find projectile source");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget != null)
        {
            AttackOnCooldown();
        }
    }

    void AttackOnCooldown()
    {
        if (Time.time > cdTimer)
        {
            cdTimer = Time.time + attackSpeed;
            ProjectileFactory.Spawn(projectilePrefab, projectileSource, currentTarget.transform);
        }
    }

    void UpdateModifiers()
    {
        foreach (var gem in gems)
        {
            gem.ApplyModifier(this.gameObject.GetComponent<Tower>());
        }
    }

    void ApplyTowerData(TowerData td)
    {
        this.damage = td.damage;
        this.radius = td.radius;
        this.attackSpeed = td.attackSpeed;
        gems.Clear();
        //Gem.Add(GemFactory.);
    }

    void TargetSelection(Collider2D collision)
    {
        if (currentTarget == null)
        {
            currentTarget = collision.gameObject;
        }
        else
        {
            if (Vector2.Distance(collision.transform.position, this.gameObject.transform.position) <
                Vector2.Distance(currentTarget.transform.position, this.gameObject.transform.position))
            {
                currentTarget = collision.gameObject;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mob")
        {
            TargetSelection(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Mob")
        {
            TargetSelection(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentTarget = null;
    }
    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
