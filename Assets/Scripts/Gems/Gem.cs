using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GemData gemData;
    public SpriteRenderer sr;
    public Sprite sprite;

    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public void ChangeGemData(GemData _gemData)
    {
        this.gemData = _gemData;
    }
}
