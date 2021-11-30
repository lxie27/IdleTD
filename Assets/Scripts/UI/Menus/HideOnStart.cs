using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnStart : MonoBehaviour
{
    public bool ShowOnStart;
    // Start is called before the first frame update
    private void Awake()
    {
        this.transform.gameObject.SetActive(ShowOnStart);
    }
}
