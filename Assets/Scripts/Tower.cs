using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float damage;
    public float radius;
    float attackCD = .5f;
    float currentCD = -1f;

    GameObject projectile;
    GameObject currentTarget;

    CircleCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        //Might change this in the future to be more generic
        coll = this.gameObject.GetComponent<CircleCollider2D>();
        coll.radius = radius;
        projectile = Instantiate(Resources.Load("PH_Projectile", typeof(GameObject))) as GameObject;
        if (projectile == null)
        {
            Debug.Log("Failed to load projectile");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget == null)
        {
            return;
        }
        else
        {
            AttackOnCooldown();
        }
        
    }

    // TODO attacking preferences
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger enter");
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

    private void OnTriggerStay2D(Collider2D collision)
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
        StopCoroutine("AttackOnCooldown");
        currentTarget = null;
    }

    void AttackOnCooldown()
    {
        if (Time.time > currentCD)
        {
            currentCD = Time.time + attackCD;
            Debug.Log("Attacking.");
            Projectile.Spawn(
                projectile, 
                this.gameObject.GetComponent("ProjectileSource").transform.position,
                 Quaternion.identity, currentTarget.transform);
        }
        
        
    }
}
