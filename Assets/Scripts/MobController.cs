using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class MobController : MonoBehaviour
{
    public float speed;
    public Vector2 facingDirection;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
