using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public GameObject target;
    public GameObject explosion;

    protected float projectileSpeed;
    protected float damage;
    protected float radius;

    public virtual void Start()
    {
        if (projectileSpeed == 0)
        {
            projectileSpeed = 20f;
        }
        if (damage == 0)
        {
            damage = 5f;
        }

        if (explosion == null)
        {
            explosion = Resources.Load("Projectiles/Base_Explosion") as GameObject;
        }
    }
    // Update is called once per frame
    public virtual void Update()
    {
        if (target != null)
        {
            // Move ourselves towards the target at every frame.
            Vector3 direction = target.transform.position - transform.position;
            transform.position += direction.normalized * projectileSpeed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == target)
        {
            other.GetComponent<Mob>().TakeDamage(damage);
            GameObject ex = Instantiate(explosion, this.transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
