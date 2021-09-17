using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Mob : MonoBehaviour
{
    public int health = 10;
    public float speed = .01f;
    AnimatorController ac;

    public bool isMoving = false;
    //bool finished = false;
    List<Vector2> path;
    int currentCell;
    Vector2 startPosition, nextPosition, endPosition;


    void Start()
    {
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
        else
        {
            for(int i = 0; i < path.Count; i++)
            {
                Debug.Log(path[i].x + " , " + path[i].y);
            }
        }

        //Move to starting position (first cell in path)
        startPosition = path[0];
        this.transform.position = startPosition;
        currentCell = 0;
        nextPosition = path[currentCell + 1];

        //Set end position to last cell (ORDER MATTERS WHEN GENERATING PATH)
        endPosition = path[path.Count - 1];
        
    }

    void Update()
    {
        if ((Vector2)this.transform.position != endPosition)
        {
            if ((Vector2)this.transform.position != nextPosition)
            {
                StartCoroutine(MoveToPoint(nextPosition));
            }
            else
            {
                nextPosition = path[currentCell++];
            }
        }
        else
        {
            Destroy(this);
        }
    }

    public IEnumerator MoveToPoint(Vector2 end)
    {
        float step = (speed / ((Vector2)this.transform.position - end).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            this.transform.position = Vector2.Lerp((Vector2)this.transform.position, end, t); // Move objectToMove closer to b
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }

        this.transform.position = end;
    }
}
