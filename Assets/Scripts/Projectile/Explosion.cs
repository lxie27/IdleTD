using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator anim;
    AnimatorClipInfo explo;

    // Start is called before the first frame update
    void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
        anim.Play("Base_Explosion");
        explo = anim.GetCurrentAnimatorClipInfo(0)[0];
        Destroy(this.gameObject, explo.clip.length);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
