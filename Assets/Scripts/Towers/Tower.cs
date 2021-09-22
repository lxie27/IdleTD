using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float damage;
    public float radius;
    float attackCD = 1f;
    float currentCD = -5f;

    GameObject projectilePrefab;
    GameObject currentTarget;

    CircleCollider2D coll;

    Transform projectileSource;

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
        if (Time.time > currentCD)
        {
            currentCD = Time.time + attackCD;
            ProjectileFactory.Spawn(projectilePrefab, projectileSource, currentTarget.transform);
        }
    }

    // TODO attacking preferences
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
