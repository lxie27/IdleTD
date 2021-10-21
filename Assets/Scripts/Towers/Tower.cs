using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerData towerData;

    float cdTimer = -1f;
    GameObject currentTarget;
    CircleCollider2D coll;
    Transform projectileSource;

    // Start is called before the first frame update
    void Start()
    {
        coll = this.gameObject.GetComponent<CircleCollider2D>();
        coll.radius = towerData.radius;
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
            cdTimer = Time.time + towerData.attackSpeed;
            ProjectileFactory.Spawn(projectileSource, currentTarget.transform);
        }
    }

    //TODO return based on subclass types
    public virtual Texture2D GetPreviewTexture()
    {
        switch (this.towerData.type)
        {
            case TowerType.Basic:
                return AssetPreview.GetAssetPreview(AssetDatabase.LoadAssetAtPath(
                    "Assets/Prefabs/Towers/BaseTower", typeof(GameObject)));
            default:
                return null;
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
            if (Vector2.Distance(collision.transform.position, 
                this.gameObject.transform.position) <
                Vector2.Distance(currentTarget.transform.position, 
                this.gameObject.transform.position))
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
    
}
