using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Mob : MonoBehaviour
{
    public int health = 10;
    public float speed = 20f;
    AnimatorController ac;

    public bool isMoving = false;
    List<Vector2> path;
    int currentCell;
    Vector2 nextPosition, endPosition;

    void Start()
    {
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

    }

    void Update()
    {
        //Debug.Log("Current position: " + this.transform.position + " , Next position: " + nextPosition);
        if ((Vector2)this.transform.position != endPosition)
        {
            if ((Vector2)this.transform.position != nextPosition)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, nextPosition, speed * Time.deltaTime); // Move objectToMove closer to b
            }
            else
            {
                nextPosition = path[++currentCell];
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
