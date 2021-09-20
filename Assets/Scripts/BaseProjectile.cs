using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public float damage;
    public GameObject target;
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == target)
        {
            Debug.Log("Projectile hit target");
            other.GetComponent<Mob>().TakeDamage(damage);
            //Destroy(gameObject);
        }
    }
}
