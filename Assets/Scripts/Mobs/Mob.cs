using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public enum Direction { NONE = 0, UP = 1, DOWN = 2, LEFT = 3, RIGHT = 4 };

public class Mob : MonoBehaviour
{
    public float originalHealth;
    public float currentHealth;
    public float speed = 3f;

    public bool isMoving = false;
    public List<Vector2> path;
    public int currentCell; //index of current position in path cell list
    Vector2 nextPosition, endPosition;

    public GameObject currentHealthBar;
    Vector3 currentHealthBarOriginalScale;
    Vector3 currentHealthBarCurrentScale;

    Direction currentDirection;
    Animator anim;
    AnimatorController ac;
    public virtual void Start()
    {
        MobInitialization();
    }

    // General initialization every mob will do, used to dodged Start inheritance
    public void MobInitialization()
    {
        this.gameObject.tag = "Mob";
        currentCell = 0;
        GameObject grid = GameObject.FindWithTag("Grid");
        if (grid == null)
        {
            Debug.Log("No grid found.");
        }
        else
        {
            path = grid.GetComponent<GridMap>().pathCells;
        }

        if (path == null)
        {
            Debug.Log("No path found.");
        }

        this.transform.position = path[currentCell];
        nextPosition = path[currentCell + 1];
        endPosition = path[path.Count - 1];

        anim = this.gameObject.GetComponent<Animator>();
        if (anim == null)
        {
            Debug.Log("Could not find this mob's animator");
        }
        else
        {
            ac = anim.GetComponent<AnimatorController>();
            currentDirection = GetNextDirection();
        }

        originalHealth = currentHealth;
        currentHealthBarOriginalScale = currentHealthBar.transform.localScale;
    }

    public virtual void Update()
    {
        if ((Vector2)this.transform.position != endPosition)
        {
            Move();
        }
        else
        {
            Despawn();
        }

        if (currentHealth <= 0)
        {
            MobKilled();
        }
    }

    //  Function to contain any scorekeeping when mob dies
    public virtual void MobKilled()
    {
        Destroy(this.gameObject);
    }

    public virtual void Despawn()
    {
        Destroy(this.gameObject);
    }

    void Move()
    {
        if ((Vector2)this.transform.position != nextPosition)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, nextPosition, speed * Time.deltaTime); // Move objectToMove closer to b
        }
        else
        {
            nextPosition = path[++currentCell];
            Direction nextDirection = GetNextDirection();
            if (nextDirection != currentDirection)
            {
                currentDirection = nextDirection;
                ChangeDirection();
            }
        }
    }

    Direction GetNextDirection()
    {
        float yDiff = nextPosition.y - ((Vector2)this.transform.position).y;
        float xDiff = nextPosition.x - ((Vector2)this.transform.position).x;

        if (yDiff > 0)
        {
            return Direction.UP;
        }
        else if (yDiff < 0)
        {
            return Direction.DOWN;
        }
        else if (xDiff > 0)
        {
            return Direction.RIGHT;
        }
        else if (xDiff < 0)
        {
            return Direction.LEFT;
        }
        else
        {
            return currentDirection;
        }
    }

    void ChangeDirection()
    {
        anim.SetInteger("Direction", (int)currentDirection);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        ChangeHealthBar();
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, transform.lossyScale);
    }

    void ChangeHealthBar()
    {
        currentHealthBar.transform.localScale = new Vector3((currentHealth / originalHealth) * currentHealthBarOriginalScale.x, 1, 1);
    }
}
