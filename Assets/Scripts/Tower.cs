using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float damage;
    public float radius;
    float attackCD = .5f;
    float currentCD = -1f;

    GameObject projectilePrefab;
    GameObject currentTarget;

    CircleCollider2D coll;


    // Start is called before the first frame update
    void Start()
    {
        //Might change this in the future to be more generic
        coll = this.gameObject.GetComponent<CircleCollider2D>();
        coll.radius = radius;
        projectilePrefab = Instantiate(Resources.Load("Projectiles/PH_Projectile", typeof(GameObject))) as GameObject;
        if (projectilePrefab == null)
        {
            Debug.Log("Failed to load projectile");
        }
        else
        {
            Debug.Log("Loaded " + projectilePrefab.name);
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

    void AttackOnCooldown()
    {
        if (Time.time > currentCD)
        {
            currentCD = Time.time + attackCD;
            GameObject go = Instantiate(projectilePrefab, 
                transform.gameObject.GetComponent("ProjectileSource").transform.position, 
                transform.rotation);
            BaseProjectile proj = go.GetComponent<BaseProjectile>();
            proj.target = currentTarget; proj.damage = damage;
        }
    }    

    void SetProjectile(GameObject proj)
    {
        projectilePrefab = proj;
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
}
