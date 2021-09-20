using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public float damage;
    public GameObject target;
    public float radius;

    public virtual void Start()
    {
        if (projectileSpeed == 0)
        {
            projectileSpeed = 10f;
        }
        if (damage == 0)
        {
            damage = 2f;
        }
    }
    // Update is called once per frame
    public virtual void Update()
    {
        if (!target)
        {
            Destroy(gameObject);
        }

        // Move ourselves towards the target at every frame.
        Vector3 direction = target.transform.position - transform.position;
        transform.position += direction.normalized * projectileSpeed * Time.deltaTime;
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == target)
        {
            Debug.Log("Projectile hit target");
            other.GetComponent<Mob>().TakeDamage(damage);
            Destroy(gameObject);
            // TODO spawn an explosion / splat effect.
        }
    }
}
